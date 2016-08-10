using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SOLID._2._Open_Closed.Before
{
    class ServicioEncriptacion
    {
        public string Encriptar(TipoEncriptacion tipo, string texto)
        {
            switch (tipo)
            {
                case TipoEncriptacion.Aes:
                    using (Aes aesAlg = Aes.Create())
                    {
                        // Create a decrytor to perform the stream transform.
                        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                        // Create the streams used for encryption.
                        using (MemoryStream msEncrypt = new MemoryStream())
                        {
                            using (
                                CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                                {
                                    //Write all data to the stream.
                                    swEncrypt.Write(texto);
                                }
                                return System.Text.Encoding.Default.GetString(msEncrypt.ToArray()); 
                            }
                        }
                    }
                case TipoEncriptacion.Sha256:
                    StringBuilder Sb = new StringBuilder();

                    using (SHA256 hash = SHA256Managed.Create())
                    {
                        Encoding enc = Encoding.UTF8;
                        Byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                        foreach (Byte b in result)
                            Sb.Append(b.ToString("x2"));
                    }

                    return Sb.ToString();
                case TipoEncriptacion.Md5:
                    using (MD5 md5Hash = MD5.Create())
                    {
                        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));

                        // Create a new Stringbuilder to collect the bytes
                        // and create a string.
                        StringBuilder sBuilder = new StringBuilder();

                        // Loop through each byte of the hashed data 
                        // and format each one as a hexadecimal string.
                        for (int i = 0; i < data.Length; i++)
                        {
                            sBuilder.Append(data[i].ToString("x2"));
                        }

                        // Return the hexadecimal string.
                        return sBuilder.ToString();
                    }
                default:
                    throw new Exception("Not supported");
            }
        }
    }

    public enum TipoEncriptacion
    {
        Aes,
        Md5,
        Sha256
    }
}

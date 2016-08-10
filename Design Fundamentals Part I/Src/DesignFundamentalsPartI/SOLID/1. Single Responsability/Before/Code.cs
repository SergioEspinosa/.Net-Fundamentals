using System;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Transactions;

namespace SOLID._1._Single_Responsability.Before
{
    class Poliza { }
    class PolizaHandler
    {
        public void Handle(Poliza poliza)
        {
            try
            {
                #region Trace
                File.AppendAllText(@"c:\temp\log.txt", $"{nameof(PolizaHandler)} started at {DateTime.Now}");
                #endregion

                #region Process

                using (var scope = new TransactionScope())
                {
                    var servicioPoliza = new ServicioWebPolizaExterno();
                    servicioPoliza.Opera105874(new RequestOpera105874());
                }
                //Code
                #endregion

                #region Notification
                MailMessage mail = new MailMessage("you@yourcompany.com", "user@hotmail.com");
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.Host = "smtp.google.com";
                mail.Subject = "this is a test email.";
                mail.Body = "this is my test email body";
                client.Send(mail);
                #endregion

                #region Trace
                File.AppendAllText(@"c:\temp\log.txt", $"{nameof(PolizaHandler)} finished at {DateTime.Now}");
                #endregion
            }
            catch (Exception excepcion)
            {
                int contExcepcionInterna = 0;
                var builder = new StringBuilder();
                builder.Append("Exception.Type" +  excepcion.GetType().Name);
                builder.Append("Exception.Message" + excepcion.Message);

                Exception excepcionInterna = excepcion.InnerException;
                while (excepcionInterna != null)
                {
                    contExcepcionInterna++;

                    string tituloExcepcionInterna = string.Format("Exception.InnerException{0}", contExcepcionInterna);

                    builder.Append(tituloExcepcionInterna + ".Type" + excepcion.InnerException.GetType().Name);
                    builder.Append(tituloExcepcionInterna + ".Message" +  excepcion.InnerException.Message);

                    excepcionInterna = excepcionInterna.InnerException;
                }

                if (excepcion.StackTrace != null)
                {
                    builder.Append("Exception.StackTrace" + excepcion.StackTrace);
                }
                File.AppendAllText(@"c:\temp\error.txt", $"{builder} occurred at {DateTime.Now}");
            }
           
        }
    }

    internal class RequestOpera105874
    {
    }

    internal class ServicioWebPolizaExterno
    {
        public void Opera105874(RequestOpera105874 requestCaducarPoliza)
        {
            throw new NotImplementedException();
        }
    }
}

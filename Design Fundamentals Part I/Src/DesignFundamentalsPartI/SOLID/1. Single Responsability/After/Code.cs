using System;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Transactions;

namespace SOLID._1._Single_Responsability.After
{
    public class Poliza { }

    class PolizaHandler
    {
        private PolizaTracer tracer;
        private PolizaNotificator notificator;
        private LogManagement logger;

        public void Handle(Poliza poliza)
        {
            try
            {
                Process(poliza);
            }
            catch (Exception excepcion)
            {
                logger.Error(excepcion);
            }
        }

        private void Process(Poliza poliza)
        {
            tracer.InitTransaction();

            #region Process

            using (var scope = new TransactionScope())
            {
                var servicioPoliza = new ServicioWebPolizaExterno();
                servicioPoliza.Opera105874(new RequestOpera105874());
            }
            //Code
            #endregion

            notificator.Send(poliza);
            tracer.EndTransaction();
        }
    }

    public class LogManagement
    {
        public void Error(Exception excepcion)
        {
            int contExcepcionInterna = 0;
            var builder = new StringBuilder();
            builder.Append("Exception.Type" + excepcion.GetType().Name);
            builder.Append("Exception.Message" + excepcion.Message);

            Exception excepcionInterna = excepcion.InnerException;
            while (excepcionInterna != null)
            {
                contExcepcionInterna++;

                string tituloExcepcionInterna = string.Format("Exception.InnerException{0}", contExcepcionInterna);

                builder.Append(tituloExcepcionInterna + ".Type" + excepcion.InnerException.GetType().Name);
                builder.Append(tituloExcepcionInterna + ".Message" + excepcion.InnerException.Message);

                excepcionInterna = excepcionInterna.InnerException;
            }

            if (excepcion.StackTrace != null)
            {
                builder.Append("Exception.StackTrace" + excepcion.StackTrace);
            }
        }

        private void Save(string message)
        {
            File.AppendAllText(@"c:\temp\error.txt", $"{message} occurred at {DateTime.Now}");
        }
    }

    public class PolizaTracer
    {
        public void InitTransaction()
        {
            File.AppendAllText(@"c:\temp\log.txt", $"{nameof(PolizaHandler)} started at {DateTime.Now}");
        }

        public void EndTransaction()
        {
            File.AppendAllText(@"c:\temp\log.txt", $"{nameof(PolizaHandler)} finished at {DateTime.Now}");
        }
    }

    public class PolizaNotificator
    {
        public void Send(Poliza poliza)
        {
            MailMessage mail = new MailMessage("you@yourcompany.com", "user@hotmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "smtp.google.com";
            mail.Subject = "this is a test email.";
            mail.Body = "this is my test email body";
            client.Send(mail);
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

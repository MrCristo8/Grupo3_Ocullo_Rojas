using System.Net.Mail;
using System.Net;
using System;

namespace PCAP.Models
{
    public class Email
    {
        public string Servidor { get; set; }
        public int Puerto { get; set; }
        public string Nombre { get; set; }
        public string Contenido { get; set; }
        public const string email = "pcapdb@hotmail.com";
        public const string password = "CROBWebDesign2017";
        public void tipoEmail(string mail)
        {
            if (mail.Contains("yahoo"))
            {
                Servidor = "smtp.mail.yahoo.com";
                Puerto = 465;
            }
            else if (mail.Contains("hotmail") || mail.Contains("outlook"))
            {
                Servidor = "smtp-mail.outlook.com";
                Puerto = 587;
            }
            else if (mail.Contains("gmail"))
            {
                Servidor = "smtp.gmail.com";
                Puerto = 587;
            }
        }
        public void enviaEmail(string emailDestino)
        {
            tipoEmail(email);
            MailMessage correo = new MailMessage();
            SmtpClient envio = new SmtpClient(Servidor, Puerto);
            try
            {
                correo.To.Clear();
                correo.Subject = "Reporte de pedido realizado por: " + Nombre;
                correo.Body = Contenido;
                correo.IsBodyHtml = true;
                correo.To.Add(emailDestino);
                correo.From = new MailAddress(email);
                envio.Credentials = new NetworkCredential(email, password);
                envio.EnableSsl = true;
                envio.Send(correo);
                Console.WriteLine("Correo enviado exitosamente...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
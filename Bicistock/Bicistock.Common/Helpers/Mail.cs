using System.Net.Mail;
using System.Net;

namespace Capa_Soporte.Helpers
{
    public class Mail
    {
        public static string SendEmail(string to, string code)
        {
            string status = string.Empty;
            string from = "bicistock@outlook.es";
            string displayName = "Bicistock";
            string body;
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(to);

                mail.Subject = "Codigo verificación";
                mail.IsBodyHtml = true;


                body = MailTemplate.CONFIRMATION_EMAIL;

                body = body.Replace("[[CODE]]", code);

                mail.Body = body;

                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.Credentials = new NetworkCredential(from, "Cuentaclase24%");
                client.EnableSsl = true;
                client.Send(mail);
                status = "Correo enviado";
            }
            catch (Exception e)
            {
                status = "Se ha producido un error: " + e.Message;
                throw;
            }
            return status;
        }
    }
}

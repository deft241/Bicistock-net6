using System.Net.Mail;
using System.Net;

namespace Capa_Soporte.Helpers
{
    public class Mail
    {
        public static string SendVerificationEmail(string to, string code)
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


                body = MailTemplate.CODE_EMAIL;

                body = body.Replace("[[CODE]]", code);
                body = body.Replace("[[YEAR]]", DateTime.Now.Year.ToString());

                mail.Body = body;

                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.Credentials = new NetworkCredential(from, "PassStock24%");
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
        public static string SendRemoveAppointmentEmail(string to)
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

                mail.Subject = "Cita Eliminada";
                mail.IsBodyHtml = true;


                body = MailTemplate.REMOVE_APPOINTMENT_EMAIL;

                body = body.Replace("[[YEAR]]", DateTime.Now.Year.ToString());

                mail.Body = body;

                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.Credentials = new NetworkCredential(from, "PassStock24%");
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
        public static string SendAppointmentEmail(string to, int idAppointment, string username, string brandName, DateTime date)
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

                mail.Subject = "Detalles Cita";
                mail.IsBodyHtml = true;


                body = MailTemplate.APPOINTMENT_EMAIL;

                body = body.Replace("[[ID_APPOINTMENT]]", idAppointment.ToString());
                body = body.Replace("[[USER_APPOINTMENT]]", username);
                body = body.Replace("[[BRAND_APPOINTMENT]]", brandName);
                body = body.Replace("[[DATE_APPOINTMENT]]", date.ToString("dd/MM/yyyy"));
                body = body.Replace("[[HOUR_APPOINTMENT]]", date.ToString("HH:mm"));
                body = body.Replace("[[YEAR]]", DateTime.Now.Year.ToString());


                mail.Body = body;

                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.Credentials = new NetworkCredential(from, "PassStock24%");
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

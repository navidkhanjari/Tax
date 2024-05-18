using System.Net.Mail;

namespace NakShop.Core.Utilities.Senders
{
    public class SendEmail
    {
        public static void Send(string To, string Subject, string Body)
        {
            MailMessage MailMessage = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("webmail.nakstore.ir");
            MailMessage.From = new MailAddress("noreply@nakstore.ir", "ناک استور");
            MailMessage.To.Add(To);
            MailMessage.Subject = Subject;
            MailMessage.Body = Body;
            MailMessage.IsBodyHtml = true;

            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("noreply@nakstore.ir", "Shk$5128433");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(MailMessage);
        }
    }
}

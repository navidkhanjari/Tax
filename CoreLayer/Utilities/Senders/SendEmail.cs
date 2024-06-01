using System.Net.Mail;

namespace CoreLayer.Utilities.Senders
{
	public class SendEmail
	{
		public static void Send(string To, string Subject, string Body)
		{
			MailMessage MailMessage = new MailMessage();
			SmtpClient SmtpServer = new SmtpClient("webmail.danamohasebannovin.ir");
			MailMessage.From = new MailAddress("noreply@danamohasebannovin.ir", "دانا محاسبان نوین");
			MailMessage.To.Add(To);
			MailMessage.Subject = Subject;
			MailMessage.Body = Body;
			MailMessage.IsBodyHtml = true;

			SmtpServer.Port = 25;
			SmtpServer.Credentials = new System.Net.NetworkCredential("noreply@danamohasebannovin.ir", "a@nr039Y6");
			SmtpServer.EnableSsl = true;

			SmtpServer.Send(MailMessage);
		}
	}
}

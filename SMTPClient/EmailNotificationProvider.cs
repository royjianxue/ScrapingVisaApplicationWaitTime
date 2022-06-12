using System.Net;
using System.Net.Mail;


namespace EmailServiceProvider
{
    public class EmailNotificationProvider
    {
        public static void SendEmail(string toMail, string body, string subject)
        {
            SmtpClient email = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential()
                {
                    UserName = "tsgvisainfohelpdesk@gmail.com",
                    Password = "mxzousakguxopzii"
                }
            };
            using (MailMessage message = new MailMessage("tsgvisainfohelpdesk@gmail.com", toMail)
            {
                Body = body,
                Subject = subject
            })
            {
                try
                {
                    email.Send(message);
                    Console.WriteLine("Email Send Successfully!");
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.InnerException.Message);
                }
            }



        }
    }
}

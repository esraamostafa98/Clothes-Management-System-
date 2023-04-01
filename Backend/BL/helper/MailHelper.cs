using System.Net.Mail;
using System.Net;

namespace WebApplication6.BL.helper
{
    public class MailHelper
    {
        public static string sendMail(string Title, string Message)
        {
            //try
            //{
            //    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //    smtp.EnableSsl = true;
            //    smtp.UseDefaultCredentials = false;
            //    smtp.Credentials = new NetworkCredential("esraamostafa9734@gmail.com", "esoesoeso123@");
            //    smtp.Send("esraamostafa9734@gmail.com", "sabahmohamed9734@gmail.com", Title,Message);

            //    return "Mail Successfly sent";

            //    //MailMessage m=new MailMessage();
            //    //m.From="";
            //    //m.To = "";
            //    //m.Subject = "";
            //}
            //catch (Exception ex)
            //{
            //    return"Mail Faild";
            //}
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("97d904461353f9", "b5996d1afbd27d"),
                EnableSsl = true
            };
            client.Send("from@example.com", "to@example.com", Title, Message);
            Console.WriteLine("Sent");
            return "sucss";

        }
    }
}

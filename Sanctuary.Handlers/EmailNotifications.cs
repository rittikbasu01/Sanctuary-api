using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Net.Sockets;

namespace Sanctuary.Handlers
{
    public class EmailNotifications
    {
        public void SendPassword(string toAddress, string userPassword)
        {
            string from = "sanctuarymanagementsystem@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, toAddress);

            string mailbody = "Hi, your password for the santuary is " + userPassword + " donot reply this is a system generated message.";
            message.Subject = "The Sanctuary login Password";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("sanctuarymanagementsystem@gmail.com", "Sanctuary123");
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

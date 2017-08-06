using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace UZticketsChecker
{
    class Mailer
    {
        public static void SendEmail(string gmail, string gpassword, string textMessage)
        {
            var fromAddress = new MailAddress(gmail, "Ticket Checker");
            var toAddress = new MailAddress(gmail, "UZ Traveller");
            string fromPassword = gpassword;
            const string subject = "Buy a ticket ";
            string body = "UZ has an available ticket. " + textMessage;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}

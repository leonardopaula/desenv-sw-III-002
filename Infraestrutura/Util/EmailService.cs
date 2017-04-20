using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Util
{
    public class EmailService
    {
        private string hostSMTP;
        private int portSMTP;
        private string userSMTP;
        private string passwordSMTP;
        private string domainSMTP;
        private bool SslSMTP;
        private string fromMail;
        private string fromName;

        public EmailService()
        {
            hostSMTP = "smtp.gmail.com";
            portSMTP = 587;
            userSMTP = "4webcommerce@gmail.com";
            passwordSMTP = "unisinos4web";
            fromMail = "4webcommerce@gmail.com";
            fromName = "4Web e-Commerce";
            SslSMTP = true;
        }

        public void SendEmail(List<string> toList, string subject, string body, bool sendBodyHTML = true)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromMail, fromName);
                mail.Subject = subject;
                mail.IsBodyHtml = sendBodyHTML;

                mail.Body = body;

                foreach (string to in toList)
                {
                    mail.To.Add(to);
                }

                var smtpClient = new SmtpClient(hostSMTP, portSMTP);
                smtpClient.EnableSsl = SslSMTP;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(userSMTP, passwordSMTP, domainSMTP);

                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

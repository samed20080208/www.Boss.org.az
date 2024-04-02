using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using www.Boss.org.az.Models.Abstracts;
using www.Boss.org.az.Models.Entity;

namespace www.Boss.org.az.Models.AutoMail
{
    static class Network
    {
        public static void SendNotf(in Person sender, in Person receives, in Notification notification)
        {
            SmtpClient client = new("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(sender.Email, sender.Password);
            try
            {
                client.Send(sender.Email, receives.Email, "New notification!", $"{notification.Text}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

using System;
using System.Net.Mail;

public static void Run(TimerInfo myTimer, TraceWriter log)
{
    log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
    MailMessage msg = new MailMessage();
    msg.From = new System.Net.Mail.MailAddress("naag@hipgroup.co.nz", "Hip Blog");
    msg.To.Add(new System.Net.Mail.MailAddress("naag@hipgroup.co.nz", "naag"));
    msg.To.Add(new System.Net.Mail.MailAddress("mikkel@hipgroup.co.nz", "Mikkel"));
 
    msg.Subject = "Mail from naag using MailJet 2!";
    msg.Body = "This is just a simple test message!";
    
    SmtpClient client = new SmtpClient("in.mailjet.com", 587);
    client.DeliveryMethod = SmtpDeliveryMethod.Network;
    client.EnableSsl = true;
    client.UseDefaultCredentials = false;
    client.Credentials = new System.Net.NetworkCredential("eba22ee2f4138ff9a46ea1927aa610a0", "0523347358d58891617f92203b7de621");
    client.Send(msg);
}

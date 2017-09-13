using System.Net;
using System.Net.Mail;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    // parse query parameter
    string name = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
        .Value;

    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();

    // Set name to query string or body data
    name = name ?? data?.name;
    MailMessage msg = new MailMessage();
    msg.From = new System.Net.Mail.MailAddress("naag@hipgroup.co.nz", "Hip Blog");
    msg.To.Add(new System.Net.Mail.MailAddress("naag@hipgroup.co.nz", "naag"));
    msg.To.Add(new System.Net.Mail.MailAddress("mikkel@hipgroup.co.nz", "Mikkel"));
 
msg.Subject = "Mail from naag using MailJet!";
msg.Body = "This is just a simple test message!";
 
SmtpClient client = new SmtpClient("in.mailjet.com", 587);
client.DeliveryMethod = SmtpDeliveryMethod.Network;
client.EnableSsl = true;
client.UseDefaultCredentials = false;
client.Credentials = new System.Net.NetworkCredential("eba22ee2f4138ff9a46ea1927aa610a0", "0523347358d58891617f92203b7de621");
client.Send(msg);
    return name == null
        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
        : req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
    
}

using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
public static void Run(TimerInfo myTimer, TraceWriter log)
{
        log.Info($"C# Queue trigger function processed: {"test"}");   
        RunAsync(log).Wait();    
}
static async Task RunAsync(TraceWriter log)    
{
        MailjetClient client = new MailjetClient("eba22ee2f4138ff9a46ea1927aa610a0", "f181d09765b200b43b1a07a1377de681")
        {
            Version = ApiVersion.V3_1,
        };
        MailjetRequest request = new MailjetRequest
        {
            Resource = Send.Resource
        }
        .Property(Send.FromEmail,"naag@hipgroup.co.nz")
        .Property(Send.FromName, "Do Not Reply")
        .Property(Send.Subject, "MailJet Timer")
        .Property(Send.TextPart, "test")
        .Property(Send.HtmlPart, "<h1>This Hip Magic!!</h1>")
        .Property(Send.Recipients, new JArray
        {
            new JObject
            {
                {"Email","naag@hipgroup.co.nz" }
            }
        });

        MailjetResponse response = await client.PostAsync(request).ConfigureAwait(false);
        if (response.IsSuccessStatusCode)
        {
            log.Info($"Total: {response.GetTotal()} Count: {response.GetCount()}");
            log.Info(response.GetData().ToString());
        }
        else
        {
            log.Error($"Status code: {response.StatusCode}  Error: {response.GetErrorInfo()}  Error message: {response.GetErrorMessage()}");
        }

}
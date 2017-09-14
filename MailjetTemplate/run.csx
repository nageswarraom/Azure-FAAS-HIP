using Mailjet.Client;
using Mailjet.Client.Resources;
using System;
using Newtonsoft.Json.Linq;

public static void Run(TimerInfo myTimer, TraceWriter log)
{
    log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
    RunAsync(log).Wait();    
}
static async Task RunAsync(TraceWriter log)    
{       
    //MailJet  
    MailjetClient client = new MailjetClient("eba22ee2f4138ff9a46ea1927aa610a0", "f181d09765b200b43b1a07a1377de681")
    {
        Version = ApiVersion.V3_1,
    };
    MailjetRequest request = new MailjetRequest
    {
            Resource = Send.Resource,
    }
            .Property(Send.Messages, new JArray {
                new JObject {
                 {"From", new JObject {
                  {"Email", "naag@hipgroup.co.nz"},
                  {"Name", "Mailjet Template with Var - C#"}
                  }},
                 {"To", new JArray {
                  new JObject {
                   {"Email", "naag@hipgroup.co.nz"},
                   {"Name", "naag"}
                   },
                  /*new JObject {
                   {"Email", "mikkel@hipgroup.co.nz"},
                   {"Name", "Mikkel"}
                   },*/
                  //new JObject {
                   //{"Email", "amanda@hipgroup.co.nz"},
                   //{"Name", "Amanda"}
                   //}
                  }},
                 /*{"TemplateErrorDeliver", true},
                 {"TemplateErrorReporting", new JObject {
                  {"Email", "naag@hipgroup.co.nz"},
                  {"Name", "Mailjet Template with Var"}
                  }},*/
                 {"TemplateID", 209327},
                 {"TemplateLanguage", true},
                 {"Subject", "Your Mailjet Template - C#!"},
                 {"Variables", new JObject {
                  {"Group", "Csharp"},
                  }},
                 //{"TextPart", "Dear Kai Member, welcome to Mailjet! May the delivery force be with you!"},
                 //{"HTMLPart", "<h3>Dear Kai Member, Welcome to Mailjet!</h3><br />May the delivery force be with you!"}
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
            log.Error($"Error Status code: {response.StatusCode}  Error: {response.GetErrorInfo()}  Error message: {response.GetErrorMessage()}");
        }  
}


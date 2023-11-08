
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using EventHubCommon.Messaging;

namespace Oklahoma.Functions
{
    public static class Dispatcher
    {
        [FunctionName("Dispatcher")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            // I'm making the key the method name i want to call (also the queue name that i will dispatch the message to.  I can add or change methods after i write this
            // Temporal decoupling again.  I think i have some messages in service bus from a couple years ago, and i can go in and use them to complete the tasks (command pattern)
            // just the same as if they were from today. 
            // Also, if i make this value a json payload i can extend it in the future no problem
            // I can easily build a dictionary with the Key, Value pairs


            string key = req.Query["Key"];
            string value = req.Query["Value"];
            string requestBody = new StreamReader(req.Body).ReadToEnd();
            log.Info("requestbody=" + requestBody);
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            
            key = key ?? data?.Key;
            value = value ?? data?.Value;

            if (key != null)
            {
                int val = int.Parse(value);
                LMMessenger.SendStorageQueueMessage(val, key);
                return (ActionResult)new OkObjectResult($"Key={key}; Value={value}");
            }
            else
            {
                return new BadRequestObjectResult("Please pass a name on the query string or in the request body");

            }



        }
    }
}
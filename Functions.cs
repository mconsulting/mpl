using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
//using Microsoft.ServiceBus.Messaging;
using Oklahoma.core.common;
using Oklahoma.core.Logic;
using Oklahoma.core.Model;
using Oklahoma.core.Entities;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage;
using EventHubCommon.Messaging;
using Newtonsoft.Json;

namespace Oklahoma.webjob
{
    public class Functions
    {
        //    // This function will get triggered/executed when a new message is written 
        //    // on an Azure Queue called queue.
        //    public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log)
        //    {

        //        try
        //        {
        //            log.WriteLine(message);

        //            int i = 0;
        //            if (int.TryParse(message, out i))
        //            {
        //                log.WriteLine("offset=" + i.ToString());
        //            };
        //            var wpm = new WebPageManager();
        //            wpm.Refresh((DateTime.Now).AddDays(-i));
        //            //   QueueNextMessage(i, 30);

        //        }
        //        catch (Exception ex)
        //        {

        //            log.WriteLine("Error in Oklahoma.webjob.Functions ProcessQueueMessage " + ex.Message);
        //        }
        //    }


        //    public static void InstrumentManagerNewJob([QueueTrigger("InstrumentManagerNewJob")] string message, TextWriter log)
        //    {

        //        try
        //        {
        //            log.WriteLine(message);

        //            int i = 0;
        //            if (int.TryParse(message, out i))
        //            {
        //                log.WriteLine("offset=" + i.ToString());
        //            };
        //            //var wpm = new WebPageManager();
        //            //wpm.Refresh((DateTime.Now).AddDays(-i));
        //            //   QueueNextMessage(i, 30);

        //        }
        //        catch (Exception ex)
        //        {

        //            log.WriteLine("Error in Oklahoma.webjob.Functions ProcessQueueMessage " + ex.Message);
        //        }
        //    }

        //    public List<Instrument> GetInstrumentHistory(string CountyName, string InstrumentNumber)
        //    {
        //        return new List<Instrument>();
        //    }


        //}
    }
}

    //private static void QueueNextMessage(int i, int Stop)
    //{
    //  //  int i = Start;

    //    if (i < Stop)
    //    {
    //        i++;
    //     //  Messenger.SendMessageAsync
    //        LMMessenger.SendStorageQueueMessage(i.ToString(), "queue");
    //    }
    //}
    //public static void DownloadPDFFromQueueMessage([QueueTrigger("pdfdocuments2")] Document message, TextWriter log)
    //{
    //    DownloadPDFFromQueueTrigger.Execute(message, log);
    //    //log.WriteLine(message);

    //    //int i = 0;
    //    //if (int.TryParse(message, out i))
    //    //{
    //    //    log.WriteLine("offset=" + i.ToString());
    //    //};
    //    //var wpm = new WebPageManager();
    //    //wpm.Refresh((DateTime.Now).AddDays(-i));
    //}
    //public static void ExecuteRemoteAgent(BrokeredMessage msg)
    //{ 
    //}
    //public static void ExecuteDocumentByDateOffset([QueueTrigger("executedocumentlist")] string message, TextWriter log)
    //{
    //    log.WriteLine(message);

    //    int i = 0;
    //    if (int.TryParse(message, out i))
    //    {
    //        log.WriteLine("offset=" + i.ToString());
    //        var wpm = new WebPageManager();
    //        wpm.Refresh((DateTime.Now).AddDays(-i));

    //       // QueueNextMessage(0, 10);


    //    }
    //}
    //public static void ExecuteDocumentById([QueueTrigger("executedocumentbyid")] string message, TextWriter log)
    //{
    //    log.WriteLine(message);
    //  //  string jsonContent = await req.Content.ReadAsStringAsync();




    //        try
    //    {
    //        dynamic data = JsonConvert.DeserializeObject(message);
    //        string DocumentId = data.DocId;
    //        bool WithContacts = data.Hierarchy == "true";
    //        var mgr = new DocumentManager();
    //        mgr.ExecuteDocumentById(DocumentId, WithContacts);
    //    }
    //    catch (Exception)
    //    {

    //        log.WriteLine("Error in ExecuteDocumentById " + message);
    //    }



    //}




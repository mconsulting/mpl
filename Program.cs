using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Oklahoma.core.Data;
using Oklahoma.core.Model;
using Oklahoma.core.common;
using Oklahoma.core.Common;
using Oklahoma.core.Logic;
using System.Net;
using Newtonsoft.Json;
using EventHubCommon.Messaging;
using Microsoft.Extensions.Hosting;

namespace Oklahoma.webjob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()

        {
            //  Functions.InstrumentManagerNewJob()
            var d = new DisconnectedADOHandler();
            var table = d.GetDataTableFromSql("select * from TractInstruments","TractInstruments");

            //   var im = new InstrumentManager();
            //    var instrument =im.GetInstrumentByID("2016000942");

            //      im.Hydrate();

            //     im.Hydrate();

            //  var wpm = new WebPageManager();
            //  wpm.Refresh(DateTime.Now.AddDays(-200));
            // have all of these been run?
            //RunQueries("MEADOWS OIL & GAS CORP");
            //  RunQueries("PETRAM");
            return;

        }
    
        public static void RunQueries(string party)

        {
          ////  return;
            RunQuery(party, "Kingfisher");
            RunQuery(party, "Blaine");
            RunQuery(party, "McClain");
            RunQuery(party, "Dewey");
            RunQuery(party, "Custer");
            RunQuery(party, "Stephens");
            RunQuery(party, "Major");
            RunQuery(party, "Garvin");
            RunQuery(party, "Hughes");
            //  RunQuery(party, "Pittsburgh");
        }
        static void RunQuery(string party, string county, int StartAt =1)
        {
            var im = new InstrumentManager(county, party, "2015-01-01", "2018-12-31",false,StartAt);
         //   var im = new InstrumentManager(county, party);
            Messenger.AddToLog("log", "InstrumentMangager initialized for " + county + " county, " + party).Wait();
            im.RunOKCountRecordsQuery();
            //    im.GetContract(county, number)
            
        }

        static void Test(string message)
        {
            try
            {
              //  log.WriteLine(message);
               
                int i = 0;
                if (int.TryParse(message, out i))
                {
                  //  log.WriteLine("offset=" + i.ToString());
                };
                var wpm = new WebPageManager();
                wpm.Refresh((DateTime.Now).AddDays(-i));
               // QueueNextMessage(i, 30);
                

            }
            catch (Exception ex)
            {

            //  log.WriteLine("Error in Oklahoma.webjob.Functions ProcessQueueMessage " + ex.Message);
            }
        }

        
    }
}

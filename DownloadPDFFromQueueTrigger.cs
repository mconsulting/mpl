using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Oklahoma.core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Oklahoma.core.Model;

namespace Oklahoma.webjob
{
    public static class DownloadPDFFromQueueTrigger
    {

        public static void Execute(Document myQueueItem,TextWriter log)
        {

            try
            {
               URL2BlobAsync(myQueueItem.SourceURL).Wait();
            }
            catch (Exception e)
            {

                log.WriteLine($"DownloadPDFFromQueue function error on: {myQueueItem}");
                log.WriteLine(JsonConvert.SerializeObject(e));
            }


        }


        private async static Task URL2BlobAsync(string Source)
        {
            Uri URL = new Uri(Source);
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("AzureWebJobsStorage"));
            string strName = URL.Segments[URL.Segments.Length - 1].ToString();
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("pdfdocuments");
            //   container.CreateIfNotExists();
            var wc = new System.Net.WebClient();

            //   Debug.WriteLine("downloading data {0}...", URL);
            byte[] ba = wc.DownloadData(URL);

            //   Debug.WriteLine("download complete {0}...", URL);
            CloudBlockBlob blob = container.GetBlockBlobReference(strName);
            //  Debug.WriteLine("uploading data {0}...", URL);
            await blob.UploadFromByteArrayAsync(ba, 0, ba.Length);
            //   Debug.WriteLine("upload complete {0}...", URL);

            // return blob.Uri.AbsoluteUri;

        }

       
    }

    
}

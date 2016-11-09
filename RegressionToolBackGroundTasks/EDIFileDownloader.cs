using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RegressionToolTasks
{
    public class EDIFileDownloader
    {

        public Boolean DownloadFile(String url, String FilePath)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    System.IO.File.WriteAllText(FilePath,Base64Decode(client.DownloadString(url)));
                    return true;
                }
            }catch(Exception e)
            {
                return false;
            }
       
        }

        private string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        
        private string ReplaceISAHeaders(String ISASender, String ISAReciever)
        {
            return "";
        }

        private string ReplaceGSHeaders(String ISASender, String ISAReciever)
        {
            return "";
        }


    }
}

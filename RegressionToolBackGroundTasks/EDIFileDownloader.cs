using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RegressionToolBackGroundTasks
{
    public class EDIFileDownloader
    {

        public Boolean downloadFile(String url, String FilePath)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(url, FilePath);
                    return true;
                }
            }catch(Exception e)
            {
                return false;
            }
       
        }

    }
}

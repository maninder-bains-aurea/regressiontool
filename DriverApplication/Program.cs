using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegressionToolTasks;

namespace DriverApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            EDIFileDownloader ediFile = new EDIFileDownloader();
            ediFile.DownloadFile("http://cyecgwp16.ec-power.com:7788/files/2513681717/567599989/content", "D:\\test123\\abc.txt1");
        }
    }
}

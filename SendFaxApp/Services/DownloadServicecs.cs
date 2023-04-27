using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Services
{
    public class DownloadServicecs
    {
        private void download(string urlToDownload, string filepath)
        { 
            WebClient webClient = new WebClient();
            webClient.DownloadFile(urlToDownload, filepath);
        }
    }
}

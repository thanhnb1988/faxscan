using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Services
{
    public class DownloadServicecs:MDOApiService
    {
        public DownloadServicecs(string baseUrl, string domain)
        {
            this.Baseurl = baseUrl;
            this.Domain = domain;

        }
        public string Token { get; set; }

        public Stream download(string Storage,string FilePath, string FileName)
        {
            var client = new HttpClient();
            string dowwnLoadUrl = String.Format("{0}/api/core/file/private/download?storage={1}&filePath={2}&fileName={3}",Baseurl, Storage, FilePath, FileName);
            var request = new HttpRequestMessage(HttpMethod.Get, dowwnLoadUrl);
            request.Headers.Add("domain", Domain);
            request.Headers.Add("Authorization", String.Format("Bearer  {0}",Token));
            var response =  client.SendAsync(request).Result;
           
            return response.Content.ReadAsStreamAsync().Result;
        }
    }
}

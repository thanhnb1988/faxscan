using Newtonsoft.Json;
using NLog;
using SendFaxApp.Model.MDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Services
{
    public class FaxSendStatusService : MDOApiService
    {
        NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public FaxSendStatusService(string baseUrl, string domain)
        {
            this.Baseurl = baseUrl;
            this.Domain = domain;

        }

        public async Task<MDOBaseResponse> SendStatus(string id, string token, List<string> address)
        {
            try
            {
                MDOBaseResponse mdobaseResponse = new MDOBaseResponse();

                var url = String.Format("{0}/api/core/channel/private/update-address-sending-status/{1}", Baseurl, id);
                var pars = buildQueryString(address);
                if (pars != null)
                {
                    url += "?" + pars;
                }
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Put, url);
                request.Headers.Add("domain", Domain);
                request.Headers.Add("Authorization", String.Format("Bearer {0}", token));
                var response = client.SendAsync(request).Result;

                logger.Info("Send fax result  url :{0} and response:{1}", url, response.StatusCode);

                if (response.IsSuccessStatusCode)
                {

                    var result = response.Content.ReadAsStringAsync().Result;

                    mdobaseResponse = JsonConvert.DeserializeObject<MDOBaseResponse>(result);
                }

                return mdobaseResponse;
            }
            catch(Exception ex)
            {
               
                logger.Error(ex.Message);
                throw ex;
            }
          
        }

        private string buildQueryString(List<string> address)
        {
            var query = string.Empty;
            if (address.Any())
            {
                bool first = true;
                foreach (var item in address)
                {
                    if (first)
                    {
                        query += String.Format("address={0}", item);
                        first = false;
                        continue;
                    }
                    query += String.Format("&address={0}", item);
                }
            }
            return query;
        }
    }
}

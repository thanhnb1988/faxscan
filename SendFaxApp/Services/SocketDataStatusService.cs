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
    public class SocketDataStatusService:MDOApiService
    {
        public SocketDataStatusService(string baseUrl, string domain)
        {
            this.Baseurl = baseUrl;
            this.Domain = domain;

        }

        public async Task<MDOBaseResponse> SendStatusSuccess(string id, string token)
        {
            try
            {
                MDOBaseResponse mdobaseResponse = new MDOBaseResponse();

                var url = String.Format("{0}/api/core/channel/private/update-status-success/{1}", Baseurl, id);
                
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Put, url);
                request.Headers.Add("domain", Domain);
                request.Headers.Add("Authorization", String.Format("Bearer {0}", token));
                var content = new StringContent("{\n    \n}", null, "application/json");
                request.Content = content;
                var response = client.SendAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {

                    var result = response.Content.ReadAsStringAsync().Result;

                    mdobaseResponse = JsonConvert.DeserializeObject<MDOBaseResponse>(result);
                }

                return mdobaseResponse;
            }
            catch (Exception ex)
            {
                NLog.Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(ex.Message);
                throw ex;
            }

        }
    }
}

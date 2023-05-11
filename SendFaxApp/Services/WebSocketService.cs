using Azure.Core;
using Newtonsoft.Json;
using SendFaxApp.Model.MDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Services
{
    public class WebSocketService:MDOApiService
    {
        private HttpClient client = new HttpClient();

        public WebSocketService(string baseUrl,string domain)
        {
            this.Baseurl = baseUrl;
            this.Domain = domain;
            
        }

        public async Task<WebSocketChanelResponse> registerChanel(string chanelRegister,string token )
        {
            WebSocketChanelResponse response = new WebSocketChanelResponse();

            var request = new HttpRequestMessage(HttpMethod.Put, String.Format("{0}/api/core/channel/private/register-fax-machine/{1}",Baseurl, chanelRegister));
            
            buildMDOApiHeader(request, token);
            var content = new StringContent("{\n    \n}", null, "application/json");
            request.Content = content;
            var res = await client.SendAsync(request);
          
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var result = res.Content.ReadAsStringAsync().Result;

                response = JsonConvert.DeserializeObject<WebSocketChanelResponse>(result);
            }
            return response;
        }

        private void buildMDOApiHeader(HttpRequestMessage request,String token)
        {
            request.Headers.Add("Domain", Domain);
            request.Headers.Add("Authorization", String.Format("Bearer {0}",token));
            
        }
    }
}

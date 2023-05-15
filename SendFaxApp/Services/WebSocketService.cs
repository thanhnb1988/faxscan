using Azure.Core;
using Newtonsoft.Json;
using SendFaxApp.Model.MDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
            WebSocketChanelResponse webSocketChanelResponse = new WebSocketChanelResponse();

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put,String.Format( "{0}/api/core/channel/private/register-fax-machine/{1}",Baseurl,chanelRegister));
            request.Headers.Add("domain", Domain);
            request.Headers.Add("Authorization", String.Format("Bearer {0}",token));
            var content = new StringContent("{\n    \n}", null, "application/json");
            request.Content = content;
            var response =  client.SendAsync(request).Result;


            if (response.IsSuccessStatusCode)
            {

                var result = response.Content.ReadAsStringAsync().Result;

                webSocketChanelResponse = JsonConvert.DeserializeObject<WebSocketChanelResponse>(result);
            }

            return webSocketChanelResponse;
        }
    }
    
}

using Newtonsoft.Json;
using NLog;
using SendFaxApp.Model.MDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Services
{
    public class AuthenService: MDOApiService
    {
        public AuthenService(string baseUrl,string domain)
        {
            this.Baseurl = baseUrl;
            this.Domain = domain;
            
        }

        public async Task<LoginRespone> login(LoginRequest loginRequest)
        {
            try
            {
                LoginRespone loginRespone = new LoginRespone();
                string url = String.Format("{0}/api/common/limitless/public/auth/login/external-api",Baseurl);
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("Accept-Language", "vi");
                request.Headers.Add("domain", Domain);
                var content = new StringContent("{\n    \"clientId\": \"" + loginRequest.ClientId + "\",\n    \"clientSecret\": \"" + loginRequest.ClientSecret + "\"\n}", null, "application/json");
                request.Content = content;
                var response = client.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {

                    var result = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<LoginRespone>(result);
                }
                else
                {
                    return null;
                }
                
            }catch(Exception ex)
            {
                NLog.Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(ex.Message);
                throw ex;
            }



        }
    }
}

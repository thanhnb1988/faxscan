using Newtonsoft.Json;
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

        public async Task<LoginRespone> login(LoginRequest request)
        {

            LoginRespone response = new LoginRespone();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage res =  client.PostAsync("/api/common/limitless/public/auth/login/external-api ", data).Result;

                if (res.IsSuccessStatusCode)
                {
   
                    var result = res.Content.ReadAsStringAsync().Result;

                    response = JsonConvert.DeserializeObject<LoginRespone>(result);
                }
                return response;
            }
            return null;
        }
    }
}

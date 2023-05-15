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

        public async Task<LoginRespone> login(LoginRequest loginRequest)
        {

            LoginRespone loginRespone = new LoginRespone();

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://service-poc.bssd.vn/api/common/limitless/public/auth/login/external-api");
            request.Headers.Add("Accept-Language", "vi");
            request.Headers.Add("domain", "poc.bssd.vn");
            var content = new StringContent("{\n    \"clientId\": \"ccde6cd5-ee8e-4c70-b2f5-4f06f685795f\",\n    \"clientSecret\": \"Pi8^UZ*kHldZ7Jlc@=WkZ7xKc2*f2dVrIZ1K\"\n}", null, "application/json");
            request.Content = content;
            var response =  client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {

                var result = response.Content.ReadAsStringAsync().Result;

                loginRespone = JsonConvert.DeserializeObject<LoginRespone>(result);
            }
            return loginRespone;
            //using (var client = new HttpClient())
            //{
            //    //Passing service base url
            //    client.BaseAddress = new Uri(Baseurl);
            //    client.DefaultRequestHeaders.Clear();
            //    var json = JsonConvert.SerializeObject(request);
            //    var data = new StringContent(json, Encoding.UTF8, "application/json");
            //    HttpResponseMessage res = client.PostAsync("/api/common/limitless/public/auth/login/external-api ", data).Result;

            //    if (res.IsSuccessStatusCode)
            //    {

            //        var result = res.Content.ReadAsStringAsync().Result;

            //        response = JsonConvert.DeserializeObject<LoginRespone>(result);
            //    }
            //    return response;
        
        }
    }
}

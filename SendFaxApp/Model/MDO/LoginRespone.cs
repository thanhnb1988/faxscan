using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Model.MDO
{
    public class LoginRespone
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public LoginData Data { get; set; }
    }
}

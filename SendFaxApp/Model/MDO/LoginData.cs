using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Model.MDO
{
    public class LoginData
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("tokenExpiredAt")]
        public long TokenExpiredAt { get; set; }

        [JsonProperty("tokenTimeout")]
        public long TokenTimeout { get; set; }
    }
}

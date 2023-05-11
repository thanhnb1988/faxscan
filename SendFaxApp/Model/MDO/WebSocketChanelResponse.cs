using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Model.MDO
{
    public class WebSocketChanelResponse
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public object Code { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
    }
}

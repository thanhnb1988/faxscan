using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Model.MDO
{
    public class FaxData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("address")]
        public string[] Address { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("attachFiles")]
        public FaxAttachFiles[] AttachFiles { get; set; }
    }
}

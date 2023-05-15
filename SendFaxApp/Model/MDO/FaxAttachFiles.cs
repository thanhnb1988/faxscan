using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Model.MDO
{
    public class FaxAttachFiles
    {
        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("filePath")]
        public string FilePath { get; set; }

        [JsonProperty("storage")]
        public string Storage { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }
    }
}

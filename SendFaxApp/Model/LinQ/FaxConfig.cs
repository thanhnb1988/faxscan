using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Model.LinQ
{
    [Table(Name = "FaxConfig")]
    public class FaxConfig
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long Id { get; set; }
        [Column]
        public string HostName { get; set; }
        [Column]
        public string SenderName { get; set; }
        [Column]
        public string CompanyName { get; set; }
        [Column]
        public string FileSaveUrl { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Model.LinQ
{
    [Table(Name = "FaxRequestAttachFiles")]
    public class FaxRequestAttachFile
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long Id { get; set; }
        [Column]
        public string FileName { get; set; }
        [Column]
        public string FilePath { get; set; }
        [Column]
        public string Storage { get; set; }
        [Column]
        public string Domain { get; set; }
        [Column]
        public int Status { get; set; }
        [Column]
        public long FaxRequestId { get; set; }

        public FaxRequest FaxRequest { get; set; }
    }
}

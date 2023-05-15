using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendFaxApp.Model.LinQ
{
    [Table(Name = "FaxRequest")]
    public class FaxRequest
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long Id { get; set; }
        [Column]
        public string RequestId { get; set; }
        [Column]
        public string Address { get; set; }
        [Column]
        public string Domain { get; set; }
        [Column]
        public string Subject { get; set; }
        [Column]
        public int Status { get; set; }

    }
}

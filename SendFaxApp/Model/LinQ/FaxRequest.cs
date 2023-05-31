using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendFaxApp.Model.LinQ
{
    [Table("FaxRequest")]
    public class FaxRequest
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public long Id { get; set; }
        [Column("RequestId"),Unique]
        public string RequestId { get; set; }
        [Column("Address")]
        public string Address { get; set; }
        [Column("Domain")]
        public string Domain { get; set; }
        [Column("Subject")]
        public string Subject { get; set; }
        [Column("Status")]
        public int Status { get; set; }
    

    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Model.LinQ
{
    [Table("FaxRequestAttachFiles")]
    public class FaxRequestAttachFile
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public long Id { get; set; }
        [Column("FileName")]
        public string FileName { get; set; }
        [Column("FilePath")]
        public string FilePath { get; set; }
        [Column("Storage")]
        public string Storage { get; set; }
        [Column("Domain")]
        public string Domain { get; set; }
        [Column("Status")]
        public int Status { get; set; }
        [Column("FaxRequestId")]
        public long FaxRequestId { get; set; }
        [Column("FaxRealPath")]
        public string FaxRealPath { get; set; }

    }
}

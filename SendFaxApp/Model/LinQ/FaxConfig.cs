using SQLite;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Model.LinQ
{
    [Table("FaxConfig")]
    public class FaxConfig
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public long Id { get; set; }
        [Column("HostName")]
        public string HostName { get; set; }
        [Column("SenderName")]
        public string SenderName { get; set; }
        [Column("CompanyName")]
        public string CompanyName { get; set; }
        [Column("FileSaveUrl")]
        public string FileSaveUrl { get; set; }
    }
}

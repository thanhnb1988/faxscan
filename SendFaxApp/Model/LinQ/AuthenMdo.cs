using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Model.LinQ
{
    [Table(Name = "AuthenMdo")]
    public class AuthenMdo
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long Id { get; set; }
        [Column]
        public string WebSocketUrl { get; set; }
        [Column]
        public string ApiUrl { get; set; }
        [Column]
        public string ClientId { get; set; }
        [Column]
        public string ClientSecret { get; set; }
        [Column]
        public string WebSocketChanel { get; set; }
        [Column]
        public string Token { get; set; }
        [Column]
        public string TokentExpiredAt { get; set; }
        [Column]
        public string TokenTimeout { get; set; }
        [Column]
        public string Domain { get; set; }
    }
}

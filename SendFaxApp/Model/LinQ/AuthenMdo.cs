using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Model.LinQ
{
    [Table( "AuthenMdo")]
    public class AuthenMdo
    {
       
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        [Column("WebSocketUrl")]
        public string WebSocketUrl { get; set; }
        [Column("ApiUrl")]
        public string ApiUrl { get; set; }
        [Column("ClientId")]
        public string ClientId { get; set; }
        [Column("ClientSecret")]
        public string ClientSecret { get; set; }
        [Column("WebSocketChanel")]
        public string WebSocketChanel { get; set; }
        [Column("Token")]
        public string Token { get; set; }
        [Column("TokentExpiredAt")]
        public string TokentExpiredAt { get; set; }
        [Column("TokenTimeout")]
        public string TokenTimeout { get; set; }
        [Column("Domain")]
        public string Domain { get; set; }
    }
}

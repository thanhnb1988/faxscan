using Castle.Core.Resource;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Model.LinQ
{
    public  class DbFaxContext:DataContext
    {
        public Table<FaxConfig> FaxConfigs;
        public Table<AuthenMdo> AuthenMdos;
        public DbFaxContext(string connection) : base(connection) { }
    }
}

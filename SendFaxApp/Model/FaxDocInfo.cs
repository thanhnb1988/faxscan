using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendFaxApp.Model
{
    public class FaxDocInfo
    {
        public FaxDocInfo()
        {
            Bodies = new List<string>();
        }
        public string DocumentName { get; set; }
        public string Body { get; set; }

        public List<string> Bodies { get; set; }
    }
}

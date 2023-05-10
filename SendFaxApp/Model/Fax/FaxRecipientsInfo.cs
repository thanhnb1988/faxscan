using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SendFaxApp.Model.Fax
{
    public class FaxRecipientsInfo
    {
        public FaxRecipientsInfo()
        {
            listFaxRecipientsItem = new List<FaxRecipientsItem>();
        }

        public List<FaxRecipientsItem> listFaxRecipientsItem { get; set; }
    }
}

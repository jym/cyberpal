using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPal.App
{
    public class AuditItem
    {
        public string MachineName { get; set; }
        public string Policy { get; set; }
        public string SubCategory { get; set; }
        public string Setting { get; set; }
        public string Value { get; set; }
        public Guid Guid { get; set; }

        public AuditItem() { }
        
        public AuditItem(AuditItem item)
        {
            MachineName = item.MachineName;
            Policy= item.Policy;
            SubCategory = item.SubCategory;
            Setting = item.Setting;
            Value = item.Value;
            Guid = item.Guid;
        }
    }
}

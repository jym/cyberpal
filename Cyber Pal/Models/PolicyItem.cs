using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPal.App
{
    public class PolicyItem
    {
        public string? Key { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Value { get; set; }
        public bool IsValid { get; set; }

        public PolicyItem() { }

        public PolicyItem(PolicyItem item)
        {
            Name = item.Name;
            Key= item.Key;
            Description = item.Description; 
            Value = item.Value; 
            IsValid = item.IsValid;
        }

    }
}

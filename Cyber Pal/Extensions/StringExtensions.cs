using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPal.App
{
    public static class StringExtensions
    {
        public static bool IsGuid(this string value)
        {
            Guid x;
            return Guid.TryParse(value, out x);
        }
    }
}

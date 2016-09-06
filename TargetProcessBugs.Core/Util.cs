using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetProcessBugs.Core
{
    public class Util
    {
        public static string Base64Encode(string text)
        {
            var byteArray = Encoding.ASCII.GetBytes(text);
            return Convert.ToBase64String(byteArray);
        }

        public static string Base64Decode(string encodedData)
        {
            var byteArray = Convert.FromBase64String(encodedData);
            return Encoding.ASCII.GetString(byteArray);
        }
    }
}

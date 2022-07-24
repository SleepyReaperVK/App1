using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tools
{
    
    public  class ListTools : List<string>
    {
        public static string MakeStringFromList(List<string> x)
        {
            string str = "";
            foreach (var item in x)
            {
                str += item.ToString();
            }
            return str;
        }

    }
}

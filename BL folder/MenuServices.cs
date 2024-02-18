using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.BL
{
    public class MenuServices
    {
        public string menuServiceName;
        public string menuServiceCode;

        public MenuServices(string name, string code)
        {
            this.menuServiceName = name;
            this.menuServiceCode = code;
        }
    }
}

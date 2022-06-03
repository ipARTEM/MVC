
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC06Scanner
{
    public class Device : IScannerDevice
    {
        public String Scan()
        {
            return "Device сканирует";
             
        }
    }

    public class JPGStream : IScannerDevice
    {
        public String Scan()
        {
            return "Сканирование и сохранение в JPG";

        }
    }
}

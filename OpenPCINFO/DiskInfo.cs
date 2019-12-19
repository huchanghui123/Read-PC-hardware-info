using System;
using System.Collections.Generic;
using System.Text;

namespace OpenPCINFO
{
    class DiskInfo
    {
        public string name;
        public string type;
        public double size;

        public DiskInfo(string name, string type, double size)
        {
            this.name = name;
            this.type = type;
            this.size = size;
        }
    }
}

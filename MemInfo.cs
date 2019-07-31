using System;
using System.Collections.Generic;
using System.Text;

namespace PCINFO
{
    class MemInfo
    {
        public string name;
        public int speed;
        public int type;
        public double size;

        public MemInfo(string name, int speed, int type, double size)
        {
            this.name = name;
            this.size = size;
            this.type = type;
            this.speed = speed;
        }
    }
    
}

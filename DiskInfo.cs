﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OpenPCINFO
{
    class DiskInfo
    {
        public string name;
        public double size;

        public DiskInfo(string name, double size)
        {
            this.name = name;
            this.size = size;
        }
    }
}

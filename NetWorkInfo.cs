﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OpenPCINFO
{
    class NetWorkInfo
    {
        public string name;
        public string manufacturer;
        public string mac;

        public NetWorkInfo(string name, string mac)
        {
            this.name = name;
            this.mac = mac;
        }

        public NetWorkInfo(string name, string manufacturer, string mac)
        {
            this.name = name;
            this.manufacturer = manufacturer;
            this.mac = mac;
        }
    }
}

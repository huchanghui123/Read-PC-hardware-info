using System;
using System.Collections.Generic;
using System.Text;

namespace OpenPCINFO
{
    class NetWorkInfo
    {
        public string name;
        public string ip;
        public string mac;
        public long speed;
        public string type;//接口类型

        public NetWorkInfo(string name, string ip)
        {
            this.name = name;
            this.ip = ip;
        }

        public NetWorkInfo(string name, string ip, string mac)
        {
            this.name = name;
            this.ip = ip;
            this.mac = mac;
        }

        public NetWorkInfo(string name, string ip, string mac, long speed, string type)
        {
            this.name = name;
            this.ip = ip;
            this.mac = mac;
            this.speed = speed;
            this.type = type;
        }

        public override string ToString()
        {
            return "name:" + this.name + " ip:" + this.ip + " mac:" + this.mac + " speed:" + this.speed + " type:" + this.type;
        }
    }
}

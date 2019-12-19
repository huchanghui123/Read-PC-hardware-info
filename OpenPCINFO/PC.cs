using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;

namespace OpenPCINFO
{
    class PC
    {
        public static string GetSystemType()
        {
            try
            {
                var st = string.Empty;
                var mos = new ManagementObjectSearcher("Select * from Win32_ComputerSystem");
                foreach (var o in mos.Get())
                {
                    var mo = (ManagementObject)o;
                    st = mo["SystemType"].ToString();
                }
                mos.Dispose();
                return st;
            }
            catch (Exception)
            {
                return "unknow";
            }
        }

        public static string GetSystemVersion()
        {
            try
            {
                var os_version = string.Empty;
                var mos = new ManagementObjectSearcher("Select * from Win32_OperatingSystem");
                foreach (var o in mos.Get())
                {
                    var mo = (ManagementObject)o;
                    os_version += mo["Caption"].ToString() + " ";
                    os_version += mo["Version"].ToString();
                }
                mos.Dispose();
                return os_version;
            }
            catch (Exception)
            {
                return "unknow";
            }
        }

        public static string GetCpuName()
        {
            try
            {
                var st = string.Empty;
                var mos = new ManagementObjectSearcher("Select * from Win32_Processor");
                foreach (var o in mos.Get())
                {
                    var mo = (ManagementObject)o;
                    st = mo["Name"].ToString();
                }
                mos.Dispose();
                return st;
            }
            catch (Exception)
            {
                return "unknow";
            }
        }

        public static string GetBoardType()
        {
            try
            {
                var st = string.Empty;
                var mos = new ManagementObjectSearcher("Select * from Win32_BaseBoard");
                foreach (var o in mos.Get())
                {
                    var mo = (ManagementObject)o;
                    st = mo["Product"].ToString();
                }
                mos.Dispose();
                return st;
            }

            catch (Exception)
            {
                return "unknow";
            }
        }

        public static string GetBios()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_BIOS");
                ManagementObjectCollection moc = mc.GetInstances();
                string strID = null;
                foreach (ManagementObject mo in moc)
                {
                    strID += mo.Properties["Manufacturer"].Value.ToString() + " ";
                    //strID += mo.Properties["Version"].Value.ToString() + " ";
                    strID += mo.Properties["Name"].Value.ToString() + " ";
                    string data = mo.Properties["ReleaseDate"].Value.ToString().Substring(0, 8);
                    strID += DateTime.ParseExact(data, "yyyyMMdd", null).ToString("yyyy/MM/dd") + " ";

                }
                mc = null;
                moc.Dispose();
                return strID;
            }
            catch (Exception)
            {
                return "unknow";
            }
        }

        public static ArrayList GetMemeryInfo()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_PhysicalMemory");
                ManagementObjectCollection moc = mc.GetInstances();
                ArrayList mem_list = new ArrayList();
                foreach (ManagementObject m in moc)
                {
                    mem_list.Add(new MemInfo(m.Properties["Manufacturer"].Value.ToString(),
                        Convert.ToInt32(m.Properties["Speed"].Value),
                        Convert.ToInt16(m.Properties["MemoryType"].Value),
                        Convert.ToDouble(m.Properties["Capacity"].Value)));
                }
                mc = null;
                moc.Dispose();
                return mem_list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static ArrayList GetDiskInfo()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc = mc.GetInstances();
                ArrayList disk_list = new ArrayList();
                foreach (ManagementObject m in moc)
                {
                    if (m.Properties["Size"].Value != null)
                    {
                        disk_list.Add(new DiskInfo(m.Properties["Caption"].Value.ToString(),
                            m.Properties["InterfaceType"].Value.ToString(),
                             Convert.ToDouble(m.Properties["Size"].Value)));
                    }
                }
                mc = null;
                moc.Dispose();
                return disk_list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static ArrayList GetMyNetWorkInfo()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapter");
                ManagementObjectCollection moc = mc.GetInstances();
                ArrayList net_list = new ArrayList();
                String Name = "";
                String MACAddress = "";
                foreach (ManagementObject m in moc)
                {
                    //物理适配器
                    if (Convert.ToBoolean(m.Properties["PhysicalAdapter"].Value.ToString()))
                    {
                        if (m.Properties["MACAddress"].Value != null)
                        {
                            Name = m.Properties["Name"].Value.ToString();
                            MACAddress = m.Properties["MACAddress"].Value.ToString();
                            net_list.Add(new NetWorkInfo(Name, MACAddress));
                        }

                    }
                }
                mc = null;
                moc.Dispose();
                return net_list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static ArrayList GetIPv4Address()
        {
            ArrayList net_list = new ArrayList();
            String Name = "";
            String IPAddress = "";
            String Mac = "";
            String NetType = "";
            long NetSpeed = 0;
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                Name = adapter.Name;
                Mac = adapter.GetPhysicalAddress().ToString();
                NetSpeed = adapter.Speed;
                NetType = adapter.NetworkInterfaceType.ToString();
                if (Mac == string.Empty)
                {
                    continue;
                }
                UnicastIPAddressInformationCollection unicastIPAddressInformation = adapter.GetIPProperties().UnicastAddresses;
                if (unicastIPAddressInformation.Count > 0)
                {
                    foreach (var item in unicastIPAddressInformation)
                    {
                        if (item.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            IPAddress = item.Address.ToString();
                            NetWorkInfo netwotk = new NetWorkInfo(Name, IPAddress, Mac, NetSpeed, NetType);
                            net_list.Add(netwotk);
                            //Console.WriteLine(netwotk.ToString());
                        }
                    }
                }
            }
            return net_list;
        }

    }
}

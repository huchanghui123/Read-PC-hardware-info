using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;
using System.Linq;

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
                            //net_list.Add(new NetWorkInfo(Name, MACAddress));
                            Console.WriteLine("Name:"+ Name+ " MACAddress:"+ MACAddress);
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
            string ping = "";
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                //Name = adapter.Name;
                Name = adapter.Description;
                Mac = BitConverter.ToString(adapter.GetPhysicalAddress().GetAddressBytes());
                NetSpeed = adapter.Speed;
                NetType = adapter.NetworkInterfaceType.ToString();
                //Console.WriteLine("Name:"+ Name+" OperationalStatus:" + adapter.OperationalStatus);
                //String temp = string.Join(":", (from z in adapter.GetPhysicalAddress().GetAddressBytes() select z.ToString("X2")).ToArray());
                if (Mac == string.Empty || Name.Contains("Microsoft"))//屏蔽系统创建的虚拟无线网卡
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
                            ping = Ping(IPAddress);
                            NetWorkInfo netwotk = new NetWorkInfo(Name, IPAddress, Mac, NetSpeed, ping, NetType);
                            net_list.Add(netwotk);
                            //bool status = PC.Ping(IPAddress);
                        }
                    }
                }
            }
            return net_list;
        }

        public static string Ping(string ip)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            //关闭Shell的使用
            p.StartInfo.UseShellExecute = false;
            //重定向标准输入
            p.StartInfo.RedirectStandardInput = true;
            //重定向标准输出
            p.StartInfo.RedirectStandardOutput = true;
            //重定向错误输出
            p.StartInfo.RedirectStandardError = true;
            //设置不显示窗口
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(string.Format("ping -n 1 -S {0} www.baidu.com", ip));
            p.StandardInput.WriteLine("exit");
            
            string strRst = p.StandardOutput.ReadToEnd();
            String[] strs =strRst.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            //foreach (string str in strs)
            //{
            //    Console.WriteLine("ping>>>>>>"+str);
            //}
            //Console.WriteLine("ping>>>>>>" + strs[6]);
            //System.IO.StringReader sr = new System.IO.StringReader(strRst);
            //Console.WriteLine("ping>>>>>>>>>>>>>"+sr.ReadLine());
            return strs[6];
        }


    }
}

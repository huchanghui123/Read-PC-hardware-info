using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Collections;


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

        public static ArrayList getNetWorkInfo()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapter");
                ManagementObjectCollection moc = mc.GetInstances();
                ArrayList net_list = new ArrayList();
                foreach (ManagementObject m in moc)
                {
                    if (Convert.ToBoolean(m.Properties["PhysicalAdapter"].Value.ToString()))
                    {
                        if (m.Properties["MACAddress"].Value != null)
                        {
                            net_list.Add(new NetWorkInfo(
                                m.Properties["Name"].Value.ToString(),
                                //m.Properties["Manufacturer"].Value.ToString(),
                                m.Properties["MACAddress"].Value.ToString()
                                ));
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
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OpenPCINFO
{
    public partial class PCINFO : Form
    {
        public ListViewItem cpu_item = null;
        public ArrayList cpuTemper = null;
        private CpuTemperatureReader cpuCelsius;
        public PCINFO()
        {
            InitializeComponent();
            NetworkChange.NetworkAvailabilityChanged += 
                new NetworkAvailabilityChangedEventHandler(Networkchanged);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            GetPcInfo();
            GetCpuTemperatures();
            GetMemoryInfo();
            GetDiskInfo();
            GetNetWorkInfo();
            timer1.Start();
        }

        private void GetPcInfo()
        {
            string os_type = PC.GetSystemType();
            string os_version = PC.GetSystemVersion();
            this.osBox.Text = os_version + " " + os_type;
            Console.WriteLine("OS info:" + os_version + " " + os_type);

            string cpu_name = PC.GetCpuName();
            this.cpuBox.Text = cpu_name;
            Console.WriteLine("CPU NAME:" + cpu_name);

            string borad_type = PC.GetBoardType();
            this.mainBoardBox.Text = borad_type;
            Console.WriteLine("borad_type:" + borad_type);

            string bios = PC.GetBios();
            this.biosBox.Text = bios;
            Console.WriteLine("BIOS:" + bios);

            cpuCelsius = new CpuTemperatureReader();

        }

         private void GetCpuTemperatures()
        {
            //行和列是否显示网格线
            tempList.GridLines = true;
            tempList.View = View.Details;
            //没有足够的空间显示时,是否添加滚动条
            tempList.Scrollable = true;

            this.tempList.Columns.Add("Name", -2, HorizontalAlignment.Left);
            this.tempList.Columns.Add("Value", -2, HorizontalAlignment.Center);
            this.tempList.Columns.Add("MinValue", -2, HorizontalAlignment.Center);
            this.tempList.Columns.Add("MaxValue", -2, HorizontalAlignment.Center);

            this.tempList.Columns[0].Width = Convert.ToUInt16(0.38 * this.tempList.Width);
            this.tempList.Columns[1].Width = Convert.ToUInt16(0.2 * this.tempList.Width);
            this.tempList.Columns[2].Width = Convert.ToUInt16(0.2 * this.tempList.Width);
            this.tempList.Columns[3].Width = Convert.ToUInt16(0.2 * this.tempList.Width);

            this.tempList.BeginUpdate();

            cpuTemper = cpuCelsius.GetTemperaturesInCelsius();
            foreach (Temperatures temperatures in cpuTemper)
            {
                cpu_item = new ListViewItem
                {
                    Text = temperatures.name
                };
                cpu_item.SubItems.Add(temperatures.value + "°C");
                cpu_item.SubItems.Add(temperatures.minvalue + "°C");
                cpu_item.SubItems.Add(temperatures.maxvalue + "°C");
                this.tempList.Items.Add(cpu_item);
            }

            this.tempList.EndUpdate();
        }
        
        //定时更新cpu温度
        private void UpdateCPUTemperatures()
        {
            cpuTemper = cpuCelsius.GetTemperaturesInCelsius();
                
            int i = 0;
            foreach (Temperatures temperatures in cpuTemper)
            {
                if (temperatures.value >= 45 && i != 4)
                {
                    this.tempList.Items[i].ForeColor = Color.Red;
                }
                else if (temperatures.value >= 50 && i == 4)
                {
                    this.tempList.Items[i].ForeColor = Color.Red;
                }
                else
                {
                    this.tempList.Items[i].ForeColor = Color.Black;
                }
                this.tempList.Items[i].SubItems[1].Text = temperatures.value + "°C";
                this.tempList.Items[i].SubItems[2].Text = temperatures.minvalue + "°C";
                this.tempList.Items[i].SubItems[3].Text = temperatures.maxvalue + "°C";

                i++;
            }
            
        }

        private void GetMemoryInfo()
        {
            ramList.GridLines = true;
            ramList.View = View.Details;

            this.ramList.Columns.Add("型号", -2, HorizontalAlignment.Left);
            this.ramList.Columns.Add("频率", -2, HorizontalAlignment.Center);
            this.ramList.Columns.Add("类型", -2, HorizontalAlignment.Center);
            this.ramList.Columns.Add("大小", -2, HorizontalAlignment.Center);

            this.ramList.Columns[0].Width = Convert.ToUInt16(0.4 * this.ramList.Width);
            this.ramList.Columns[1].Width = Convert.ToUInt16(0.2 * this.ramList.Width);
            this.ramList.Columns[2].Width = Convert.ToUInt16(0.2 * this.ramList.Width);
            this.ramList.Columns[3].Width = Convert.ToUInt16(0.18 * this.ramList.Width);

            this.ramList.BeginUpdate();
            ArrayList mem_info = PC.GetMemeryInfo();
            foreach (MemInfo mem in mem_info)
            {
                var mem_item = new ListViewItem();
                if (mem.name.Equals("0710")|| mem.name.Equals("1310"))
                {
                    mem_item.Text = "Kimtigo";
                }
                else
                {
                    mem_item.Text = mem.name;
                }

                mem_item.SubItems.Add(mem.speed + " MHz");
                if (mem.speed >= 2133)
                {
                    mem_item.SubItems.Add("DDR4");
                }
                else
                {
                    mem_item.SubItems.Add("DDR3");
                }
                mem_item.SubItems.Add((mem.size / 1024 / 1024 / 1024).ToString("f1") + " GB");
                this.ramList.Items.Add(mem_item);
            }
            this.ramList.EndUpdate();
        }

        private void GetDiskInfo()
        {
            diskList.GridLines = true;
            diskList.View = View.Details;
            this.diskList.Columns.Add("磁盘型号", -2, HorizontalAlignment.Left);
            this.diskList.Columns.Add("磁盘类型", -2, HorizontalAlignment.Center);
            this.diskList.Columns.Add("磁盘大小", -2, HorizontalAlignment.Center);

            this.diskList.Columns[0].Width = Convert.ToUInt16(0.55 * this.diskList.Width);
            this.diskList.Columns[1].Width = Convert.ToUInt16(0.2 * this.diskList.Width);
            this.diskList.Columns[2].Width = Convert.ToUInt16(0.2 * this.diskList.Width);

            this.diskList.BeginUpdate();

            ArrayList disk_info = PC.GetDiskInfo();
            foreach (DiskInfo disk in disk_info)
            {
                var disk_item = new ListViewItem
                {
                    Text = disk.name
                };
                disk_item.SubItems.Add(disk.type);
                disk_item.SubItems.Add((disk.size / 1024 / 1024 / 1024).ToString("f1") + " GB");
                this.diskList.Items.Add(disk_item);
            }
            this.diskList.EndUpdate();

        }

        private void GetNetWorkInfo()
        {
            netList.GridLines = true;
            netList.View = View.Details;
            this.netList.Columns.Add("适配器", -2, HorizontalAlignment.Left);
            this.netList.Columns.Add("MAC地址", -2, HorizontalAlignment.Left);
            this.netList.Columns.Add("IP地址", -2, HorizontalAlignment.Left);
            this.netList.Columns.Add("速度", -2, HorizontalAlignment.Left);
            this.netList.Columns.Add("类型", -2, HorizontalAlignment.Left);

            this.netList.Columns[0].Width = Convert.ToUInt16(0.4 * this.netList.Width);
            this.netList.Columns[1].Width = Convert.ToUInt16(0.25 * this.netList.Width);
            this.netList.Columns[2].Width = Convert.ToUInt16(0.22 * this.netList.Width);
            this.netList.Columns[3].Width = Convert.ToUInt16(0.15 * this.netList.Width);
            this.netList.Columns[4].Width = Convert.ToUInt16(0.15 * this.netList.Width);

            this.netList.BeginUpdate();
            ArrayList net_info = PC.GetIPv4Address();
            foreach (NetWorkInfo net in net_info)
            {
                var net_item = new ListViewItem
                {
                    Text = net.name
                };
                net_item.SubItems.Add(net.mac);
                net_item.SubItems.Add(net.ip);
                if (net.speed <= 0)
                {
                    net_item.ForeColor = Color.Red;
                    net_item.SubItems.Add("0 mbps");
                }
                else
                {
                    net_item.ForeColor = Color.Black;
                    net_item.SubItems.Add((net.speed / 1000 / 1000).ToString() + " mbps");
                }
                net_item.SubItems.Add(net.type);
                this.netList.Items.Add(net_item);
            }
            this.netList.EndUpdate();
        }

        private void UpdateNetWorkInfo(ArrayList list)
        {
            int i = 0;
            foreach (NetWorkInfo net in list)
            {
                Invoke((EventHandler)(delegate
                {
                    this.netList.Items[i].SubItems[0].Text = net.name;
                    this.netList.Items[i].SubItems[1].Text = net.ip;
                    if (net.speed <= 0)
                    {
                        this.netList.Items[i].ForeColor = Color.Red;
                        this.netList.Items[i].SubItems[2].Text = "0 mbps";
                    }
                    else
                    {
                        this.netList.Items[i].ForeColor = Color.Black;
                        this.netList.Items[i].SubItems[2].Text = (net.speed / 1000 / 1000).ToString() + " mbps";
                    }
                    this.netList.Items[i].SubItems[3].Text = net.type;
                }));
                i++;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Invoke((EventHandler)(delegate
            {
                UpdateCPUTemperatures();
            }));
        }

        private void Networkchanged(object sender, NetworkAvailabilityEventArgs e)
        {
            ArrayList net_info = PC.GetIPv4Address();
            UpdateNetWorkInfo(net_info);
        }

        private void Pcinfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            cpuCelsius.Dispose();
        }
    }
}

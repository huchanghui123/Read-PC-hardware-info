using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OpenPCINFO
{
    public partial class PCINFO : Form
    {
        public System.Timers.Timer timer = null;
        public ListViewItem cpu_item = null;
        public ArrayList cpuTemper = null;
        private static int inTimer = 0;

        public PCINFO()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form_Closing);

            GetPcInfo();
            GetCpuTemperatures();
            GetMemoryInfo();
            GetDiskInfo();
            GetNetWorkInfo();
        }

        private void GetTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.AutoReset = true;  
            timer.Start();
            timer.Elapsed += Timer_Elapsed;
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
        }

         private void GetCpuTemperatures()
        {
            //行和列是否显示网格线
            tempList.GridLines = true;
            tempList.View = View.Details;
            //没有足够的空间显示时,是否添加滚动条
            tempList.Scrollable = true;

            this.tempList.Columns.Add("Name", 200, HorizontalAlignment.Left);
            this.tempList.Columns.Add("Value", 50, HorizontalAlignment.Left);

            this.tempList.BeginUpdate();

            cpuTemper = CPUTemperatures.GetTemperature();
            foreach (Temperatures temperatures in cpuTemper)
            {
                cpu_item = new ListViewItem();
                cpu_item.Text = temperatures.name;
                cpu_item.SubItems.Add(temperatures.value + "°C");
                this.tempList.Items.Add(cpu_item);
            }

            this.tempList.EndUpdate();

            if (timer == null)
            {
                GetTimer();
            }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //事件内异步调用委托方法
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateUICallBack(UpdateCPUTemperatures));
            }
        }
        //定义委托
        private delegate void UpdateUICallBack();
        private void UpdateCPUTemperatures()
        {
            if (inTimer == 0)
            {
                inTimer = 1;
                cpuTemper = CPUTemperatures.GetTemperature();
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

                    i++;
                }
                inTimer = 0;
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
            this.diskList.Columns.Add("型号", -2, HorizontalAlignment.Left);
            this.diskList.Columns.Add("大小", -2, HorizontalAlignment.Center);

            this.diskList.Columns[0].Width = Convert.ToUInt16(0.6 * this.diskList.Width);
            this.diskList.Columns[1].Width = Convert.ToUInt16(0.2 * this.diskList.Width);

            this.diskList.BeginUpdate();

            ArrayList disk_info = PC.GetDiskInfo();
            foreach (DiskInfo disk in disk_info)
            {
                var disk_item = new ListViewItem();
                disk_item.Text = disk.name;
                disk_item.SubItems.Add((disk.size / 1024 / 1024 / 1024).ToString("f1") + " GB");
                this.diskList.Items.Add(disk_item);
            }
            this.diskList.EndUpdate();

        }

        private void GetNetWorkInfo()
        {
            netList.GridLines = true;
            netList.View = View.Details;
            this.netList.Columns.Add("网络适配器", -2, HorizontalAlignment.Left);
            this.netList.Columns.Add("MAC地址", -2, HorizontalAlignment.Left);

            this.netList.Columns[0].Width = Convert.ToUInt16(0.7 * this.netList.Width);
            this.netList.Columns[1].Width = Convert.ToUInt16(0.28 * this.netList.Width);

            this.netList.BeginUpdate();
            ArrayList net_info = PC.getNetWorkInfo();
            foreach (NetWorkInfo net in net_info)
            {
                var net_item = new ListViewItem();
                net_item.Text = net.name;
                net_item.SubItems.Add(net.mac);
                this.netList.Items.Add(net_item);
            }
            this.netList.EndUpdate();
        }


        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Enabled = false;
            timer.Dispose();
            Console.WriteLine("windows close!!!");
            System.Environment.Exit(0);
        }
    }
}

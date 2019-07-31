using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace PCINFO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetComputerInfo();
        }

        private void GetComputerInfo()
        {
            string os_type = PC.GetSystemType();
            string os_version = PC.GetSystemVersion();
            this.os_box.Text = os_version + " " + os_type;
            Console.WriteLine("OS TYPE:" + os_version + " " + os_type);

            string cpu_name = PC.GetCpuName();
            this.cpu_name_box.Text = cpu_name;
            Console.WriteLine("CPU NAME:"+cpu_name);

            string cpu_factuer = PC.GetCpuManufacturer();
            this.cpu_f_box.Text = cpu_factuer;
            Console.WriteLine("CPU Manufacturer:" + cpu_factuer);

            string borad_type = PC.GetBoardType();
            this.board_type_box.Text = borad_type;
            Console.WriteLine("borad_type:" + borad_type);

            string bios = PC.GetBiosInfo();
            this.bios_box.Text = bios;
            Console.WriteLine("BIOS:" + bios);

            DiskInfo();
            MemoryInfo();
            NetWorkInfo();
        }

        private void DiskInfo()
        {
            disk_list.View = View.Details;
            //disk_list.SmallImageList = imageList;
            this.disk_list.Columns.Add("硬盘序列号", -1, HorizontalAlignment.Left);
            this.disk_list.Columns.Add("硬盘大小", -2, HorizontalAlignment.Left);

            this.disk_list.Columns[0].Width = Convert.ToUInt16(0.75 * this.disk_list.Width);
            //this.disk_list.Columns[1].Width = Convert.ToUInt16(0.25 * this.disk_list.Width);

            this.disk_list.BeginUpdate();
            ArrayList disk_info = PC.GetDiskInfo();
            foreach (DiskInfo disk in disk_info)
            {
                var disk_item = new ListViewItem();
                disk_item.Text = disk.name;
                disk_item.SubItems.Add((disk.size / 1024 / 1024 / 1024).ToString("f1")+ " GB");
                this.disk_list.Items.Add(disk_item);
            }
            this.disk_list.EndUpdate();
        }

        private void MemoryInfo()
        {
            mem_list.View = View.Details;
            //disk_list.SmallImageList = imageList;
            this.mem_list.Columns.Add("内存厂商", -2, HorizontalAlignment.Left);
            this.mem_list.Columns.Add("内存频率", -2, HorizontalAlignment.Left);
            this.mem_list.Columns.Add("内存类型", -2, HorizontalAlignment.Left);
            this.mem_list.Columns.Add("内存大小", -2, HorizontalAlignment.Left);

            this.mem_list.Columns[0].Width = Convert.ToUInt16(0.5 *this.mem_list.Width);
            this.mem_list.Columns[1].Width = Convert.ToUInt16(0.15 * this.mem_list.Width);
            this.mem_list.Columns[2].Width = Convert.ToUInt16(0.15 * this.mem_list.Width);
            //this.mem_list.Columns[2].Width = Convert.ToUInt16(0.25 * this.mem_list.Width);

            this.mem_list.BeginUpdate();
            ArrayList mem_info = PC.GetMemeryInfo();
            foreach (MemInfo mem in mem_info)
            {
                var mem_item = new ListViewItem();
                if (mem.name.Equals("0710"))
                {
                    mem_item.Text = "Kimtigo";
                }
                else
                {
                    mem_item.Text = mem.name;
                }
                
                mem_item.SubItems.Add(mem.speed+" MHz");
                if (mem.speed >= 2133)
                {
                    mem_item.SubItems.Add("DDR4");
                }
                else
                {
                    mem_item.SubItems.Add("DDR3");
                }
                mem_item.SubItems.Add((mem.size / 1024 / 1024 / 1024).ToString("f1") + " GB");
                this.mem_list.Items.Add(mem_item);
            }
            this.mem_list.EndUpdate();
        }

        private void NetWorkInfo()
        {
            net_list.View = View.Details;
            this.net_list.Columns.Add("适配器名称", -1, HorizontalAlignment.Left);
            this.net_list.Columns.Add("制造商", -1, HorizontalAlignment.Left);
            this.net_list.Columns.Add("MAC地址", -1, HorizontalAlignment.Left);

            this.net_list.BeginUpdate();
            ArrayList net_info = PC.getNetWorkInfo();
            foreach (NetWorkInfo net in net_info)
            {
                var net_item = new ListViewItem();
                net_item.Text = net.name;
                net_item.SubItems.Add(net.manufacturer);
                net_item.SubItems.Add(net.mac);
                this.net_list.Items.Add(net_item);
            }
            this.net_list.EndUpdate();

        }
    }
}

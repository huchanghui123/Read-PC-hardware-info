namespace OpenPCINFO
{
    partial class PCINFO
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PCINFO));
            this.os = new System.Windows.Forms.Label();
            this.osBox = new System.Windows.Forms.TextBox();
            this.cpuBox = new System.Windows.Forms.TextBox();
            this.cpu = new System.Windows.Forms.Label();
            this.mainBoardBox = new System.Windows.Forms.TextBox();
            this.mainBroad = new System.Windows.Forms.Label();
            this.biosBox = new System.Windows.Forms.TextBox();
            this.bios = new System.Windows.Forms.Label();
            this.cpuTemp = new System.Windows.Forms.Label();
            this.ramList = new System.Windows.Forms.ListView();
            this.ram = new System.Windows.Forms.Label();
            this.diskList = new System.Windows.Forms.ListView();
            this.disk = new System.Windows.Forms.Label();
            this.netList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tempList = new OpenPCINFO.ListViewNF();
            //this.tempList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // os
            // 
            this.os.AutoSize = true;
            this.os.Font = new System.Drawing.Font("宋体", 9F);
            this.os.Location = new System.Drawing.Point(29, 9);
            this.os.Name = "os";
            this.os.Size = new System.Drawing.Size(65, 12);
            this.os.TabIndex = 0;
            this.os.Text = "操作系统：";
            // 
            // osBox
            // 
            this.osBox.BackColor = System.Drawing.Color.White;
            this.osBox.Location = new System.Drawing.Point(100, 6);
            this.osBox.Name = "osBox";
            this.osBox.ReadOnly = true;
            this.osBox.Size = new System.Drawing.Size(452, 21);
            this.osBox.TabIndex = 1;
            // 
            // cpuBox
            // 
            this.cpuBox.BackColor = System.Drawing.Color.White;
            this.cpuBox.Location = new System.Drawing.Point(100, 34);
            this.cpuBox.Name = "cpuBox";
            this.cpuBox.ReadOnly = true;
            this.cpuBox.Size = new System.Drawing.Size(452, 21);
            this.cpuBox.TabIndex = 2;
            // 
            // cpu
            // 
            this.cpu.AutoSize = true;
            this.cpu.Location = new System.Drawing.Point(59, 37);
            this.cpu.Name = "cpu";
            this.cpu.Size = new System.Drawing.Size(35, 12);
            this.cpu.TabIndex = 3;
            this.cpu.Text = "CPU：";
            // 
            // mainBoardBox
            // 
            this.mainBoardBox.BackColor = System.Drawing.Color.White;
            this.mainBoardBox.Location = new System.Drawing.Point(100, 62);
            this.mainBoardBox.Name = "mainBoardBox";
            this.mainBoardBox.ReadOnly = true;
            this.mainBoardBox.Size = new System.Drawing.Size(452, 21);
            this.mainBoardBox.TabIndex = 4;
            // 
            // mainBroad
            // 
            this.mainBroad.AutoSize = true;
            this.mainBroad.Location = new System.Drawing.Point(53, 65);
            this.mainBroad.Name = "mainBroad";
            this.mainBroad.Size = new System.Drawing.Size(41, 12);
            this.mainBroad.TabIndex = 5;
            this.mainBroad.Text = "主板：";
            // 
            // biosBox
            // 
            this.biosBox.BackColor = System.Drawing.Color.White;
            this.biosBox.Location = new System.Drawing.Point(100, 90);
            this.biosBox.Name = "biosBox";
            this.biosBox.ReadOnly = true;
            this.biosBox.Size = new System.Drawing.Size(452, 21);
            this.biosBox.TabIndex = 6;
            // 
            // bios
            // 
            this.bios.AutoSize = true;
            this.bios.Location = new System.Drawing.Point(53, 93);
            this.bios.Name = "bios";
            this.bios.Size = new System.Drawing.Size(41, 12);
            this.bios.TabIndex = 7;
            this.bios.Text = "BIOS：";
            // 
            // cpuTemp
            // 
            this.cpuTemp.AutoSize = true;
            this.cpuTemp.Location = new System.Drawing.Point(35, 118);
            this.cpuTemp.Name = "cpuTemp";
            this.cpuTemp.Size = new System.Drawing.Size(59, 12);
            this.cpuTemp.TabIndex = 9;
            this.cpuTemp.Text = "CPU温度：";
            // 
            // ramList
            // 
            this.ramList.HideSelection = false;
            this.ramList.Location = new System.Drawing.Point(100, 235);
            this.ramList.Name = "ramList";
            this.ramList.Size = new System.Drawing.Size(452, 100);
            this.ramList.TabIndex = 10;
            this.ramList.UseCompatibleStateImageBehavior = false;
            // 
            // ram
            // 
            this.ram.AutoSize = true;
            this.ram.Location = new System.Drawing.Point(29, 235);
            this.ram.Name = "ram";
            this.ram.Size = new System.Drawing.Size(65, 12);
            this.ram.TabIndex = 11;
            this.ram.Text = "内存信息：";
            // 
            // diskList
            // 
            this.diskList.HideSelection = false;
            this.diskList.Location = new System.Drawing.Point(100, 342);
            this.diskList.Name = "diskList";
            this.diskList.Size = new System.Drawing.Size(452, 100);
            this.diskList.TabIndex = 12;
            this.diskList.UseCompatibleStateImageBehavior = false;
            // 
            // disk
            // 
            this.disk.AutoSize = true;
            this.disk.Location = new System.Drawing.Point(29, 342);
            this.disk.Name = "disk";
            this.disk.Size = new System.Drawing.Size(65, 12);
            this.disk.TabIndex = 13;
            this.disk.Text = "磁盘信息：";
            // 
            // netList
            // 
            this.netList.HideSelection = false;
            this.netList.Location = new System.Drawing.Point(100, 449);
            this.netList.Name = "netList";
            this.netList.Size = new System.Drawing.Size(452, 150);
            this.netList.TabIndex = 14;
            this.netList.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 449);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "网卡信息：";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // tempList
            // 
            this.tempList.HideSelection = false;
            this.tempList.Location = new System.Drawing.Point(100, 118);
            this.tempList.Name = "tempList";
            this.tempList.Size = new System.Drawing.Size(452, 110);
            this.tempList.TabIndex = 8;
            this.tempList.UseCompatibleStateImageBehavior = false;
            // 
            // PCINFO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 611);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.netList);
            this.Controls.Add(this.disk);
            this.Controls.Add(this.diskList);
            this.Controls.Add(this.ram);
            this.Controls.Add(this.ramList);
            this.Controls.Add(this.cpuTemp);
            this.Controls.Add(this.tempList);
            this.Controls.Add(this.bios);
            this.Controls.Add(this.biosBox);
            this.Controls.Add(this.mainBroad);
            this.Controls.Add(this.mainBoardBox);
            this.Controls.Add(this.cpu);
            this.Controls.Add(this.cpuBox);
            this.Controls.Add(this.osBox);
            this.Controls.Add(this.os);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PCINFO";
            this.Text = "PCINFO V2.0";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label os;
        private System.Windows.Forms.TextBox osBox;
        private System.Windows.Forms.TextBox cpuBox;
        private System.Windows.Forms.Label cpu;
        private System.Windows.Forms.TextBox mainBoardBox;
        private System.Windows.Forms.Label mainBroad;
        private System.Windows.Forms.TextBox biosBox;
        private System.Windows.Forms.Label bios;
        //private System.Windows.Forms.ListView tempList;
        private ListViewNF tempList;
        private System.Windows.Forms.Label cpuTemp;
        private System.Windows.Forms.ListView ramList;
        private System.Windows.Forms.Label ram;
        private System.Windows.Forms.ListView diskList;
        private System.Windows.Forms.Label disk;
        private System.Windows.Forms.ListView netList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}


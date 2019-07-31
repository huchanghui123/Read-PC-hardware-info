namespace PCINFO
{
    partial class Form1
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
            this.cpu_name = new System.Windows.Forms.Label();
            this.cpu_name_box = new System.Windows.Forms.TextBox();
            this.cpu_facuter = new System.Windows.Forms.Label();
            this.cpu_f_box = new System.Windows.Forms.TextBox();
            this.os = new System.Windows.Forms.Label();
            this.os_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.board_type_box = new System.Windows.Forms.TextBox();
            this.bios_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.disk_list = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.mem_list = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.net_list = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // cpu_name
            // 
            this.cpu_name.AutoSize = true;
            this.cpu_name.Location = new System.Drawing.Point(23, 35);
            this.cpu_name.Name = "cpu_name";
            this.cpu_name.Size = new System.Drawing.Size(59, 12);
            this.cpu_name.TabIndex = 0;
            this.cpu_name.Text = "CPU名称：";
            // 
            // cpu_name_box
            // 
            this.cpu_name_box.Location = new System.Drawing.Point(88, 32);
            this.cpu_name_box.Name = "cpu_name_box";
            this.cpu_name_box.Size = new System.Drawing.Size(513, 21);
            this.cpu_name_box.TabIndex = 1;
            // 
            // cpu_facuter
            // 
            this.cpu_facuter.AutoSize = true;
            this.cpu_facuter.Location = new System.Drawing.Point(11, 63);
            this.cpu_facuter.Name = "cpu_facuter";
            this.cpu_facuter.Size = new System.Drawing.Size(71, 12);
            this.cpu_facuter.TabIndex = 3;
            this.cpu_facuter.Text = "CPU制造商：";
            // 
            // cpu_f_box
            // 
            this.cpu_f_box.Location = new System.Drawing.Point(88, 60);
            this.cpu_f_box.Name = "cpu_f_box";
            this.cpu_f_box.Size = new System.Drawing.Size(513, 21);
            this.cpu_f_box.TabIndex = 4;
            // 
            // os
            // 
            this.os.AutoSize = true;
            this.os.Location = new System.Drawing.Point(17, 7);
            this.os.Name = "os";
            this.os.Size = new System.Drawing.Size(65, 12);
            this.os.TabIndex = 10;
            this.os.Text = "系统类型：";
            // 
            // os_box
            // 
            this.os_box.Location = new System.Drawing.Point(88, 4);
            this.os_box.Name = "os_box";
            this.os_box.Size = new System.Drawing.Size(513, 21);
            this.os_box.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "主板型号：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "BIOS版本：";
            // 
            // board_type_box
            // 
            this.board_type_box.Location = new System.Drawing.Point(88, 88);
            this.board_type_box.Name = "board_type_box";
            this.board_type_box.Size = new System.Drawing.Size(513, 21);
            this.board_type_box.TabIndex = 20;
            // 
            // bios_box
            // 
            this.bios_box.Location = new System.Drawing.Point(88, 115);
            this.bios_box.Name = "bios_box";
            this.bios_box.Size = new System.Drawing.Size(513, 21);
            this.bios_box.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "硬盘信息：";
            // 
            // disk_list
            // 
            this.disk_list.GridLines = true;
            this.disk_list.Location = new System.Drawing.Point(88, 142);
            this.disk_list.Name = "disk_list";
            this.disk_list.Size = new System.Drawing.Size(513, 91);
            this.disk_list.TabIndex = 25;
            this.disk_list.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "内存信息：";
            // 
            // mem_list
            // 
            this.mem_list.GridLines = true;
            this.mem_list.Location = new System.Drawing.Point(88, 239);
            this.mem_list.Name = "mem_list";
            this.mem_list.Size = new System.Drawing.Size(513, 73);
            this.mem_list.TabIndex = 27;
            this.mem_list.UseCompatibleStateImageBehavior = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "网卡信息：";
            // 
            // net_list
            // 
            this.net_list.GridLines = true;
            this.net_list.Location = new System.Drawing.Point(88, 319);
            this.net_list.Name = "net_list";
            this.net_list.Size = new System.Drawing.Size(513, 165);
            this.net_list.TabIndex = 29;
            this.net_list.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 494);
            this.Controls.Add(this.net_list);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mem_list);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.disk_list);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bios_box);
            this.Controls.Add(this.board_type_box);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.os_box);
            this.Controls.Add(this.os);
            this.Controls.Add(this.cpu_f_box);
            this.Controls.Add(this.cpu_facuter);
            this.Controls.Add(this.cpu_name_box);
            this.Controls.Add(this.cpu_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "计算机硬件信息 V1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cpu_name;
        private System.Windows.Forms.TextBox cpu_name_box;
        private System.Windows.Forms.Label cpu_facuter;
        private System.Windows.Forms.TextBox cpu_f_box;
        private System.Windows.Forms.Label os;
        private System.Windows.Forms.TextBox os_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox board_type_box;
        private System.Windows.Forms.TextBox bios_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView disk_list;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView mem_list;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView net_list;
    }
}


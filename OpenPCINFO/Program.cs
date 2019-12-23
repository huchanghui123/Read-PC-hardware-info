using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace OpenPCINFO
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!AllRequiredFilesAvailable())
                Environment.Exit(0);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PCINFO form = new PCINFO();
            form.FormClosed += delegate (Object sender, FormClosedEventArgs e) {
                Application.Exit();
            };
            Application.Run(form);
            
        }

        private static bool IsFileAvailable(string fileName)
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) +
              Path.DirectorySeparatorChar;

            if (!File.Exists(path + fileName))
            {
                MessageBox.Show("找不到以下文件: " + fileName +
                  "\n请将该文件与程序放在同一路径.", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private static bool AllRequiredFilesAvailable()
        {
            if (!IsFileAvailable("OpenHardwareMonitorLib.dll"))
                return false;

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screen_Capture_Recorder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process.Start("https://www.facebook.com/groups/ytbStreamer/");
            Process.Start("https://www.youtube.com/channel/UC-f49x7YJENSmpIPMeoTX2Q?sub_confirmation=1");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

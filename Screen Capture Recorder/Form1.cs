using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screen_Capture_Recorder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadCombobox();
        }

        Code code = new Code();

        void loadCombobox()
        {
            cbbFfmpegCode.DataSource = code.getAllFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadCombobox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string codeLive = "";
            if (cbbFfmpegCode.Items.Count == 0)
            {
                codeLive = "";
            }
            else
            {
                codeLive = File.ReadAllText(string.Format(".\\ffmpeg code\\{0}", cbbFfmpegCode.SelectedItem.ToString()));
            }

            if (cbbFfmpegCode.Items.Count > 0 && !codeLive.Contains("ffmpeg -y -i \"{input}.*\"") && !codeLive.Contains("{output}.mp4"))
            {
                MessageBox.Show("Code ffmpeg không đúng định dạng, xoá đi hoặc nhập lại code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                codeLive = code.codeLive(cbbFfmpegCode.Items.Count, tbOutput.Text, codeLive);
            }

            Process.Start("cmd.exe", "/k " + codeLive);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

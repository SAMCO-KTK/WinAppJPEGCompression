using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppJPEGCompression
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = folderBrowserDialog1.SelectedPath;
                }
            }

            ImageClass img = new ImageClass();
            var listFile = Directory.GetFiles(textBox1.Text);
            progressBar1.Maximum = listFile.Length;
            foreach (var x in listFile)
            {
                img.SetJPEGCompression(x, 70L);
                progressBar1.Invoke((Action)(() => progressBar1.Value += 1));
                if (progressBar1.Value == listFile.Length)
                {
                    MessageBox.Show(listFile.Length + " files optimized");
                }
            }
        }

        private async Task SetProgress()
        {
          await Task.Run(() =>  progressBar1.Value += 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}

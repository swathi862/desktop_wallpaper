using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Desktop_Wallpaper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "C:\\Users\\caran\\workspace\\practice\\desktop_wallpaper\\Desktop_Wallpaper\\wallpaper.ps1";
            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy ByPass -File \"{path}\"",
                UseShellExecute = false
            };
            Process.Start(startInfo);

            button1.Text = "fingers crossed!";
        }
    }
}

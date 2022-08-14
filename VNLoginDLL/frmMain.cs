using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNLoginDLL
{
    public partial class frmMain : Form
    {
        
        public frmMain()
        {
            InitializeComponent();
        }

        string proxytype = "no";
        string ip = "";
        string port = "";
        string userproxy = "";
        string passproxy = "";
        string Orbitar = Application.StartupPath + "\\data\\orbita-browser\\";

        private void btnwin_Click(object sender, EventArgs e)
        {
            //user license
            //pass license
            //tên profile
            //loại proxy (hỗ trợ 3 định dạng): http, socks4, socks5
            //ip
            //port
            //userip
            //passip
            //trang web mở cùng profile
            string id = VNLoginDLL.Win("vnlogin", "vnlogin", "Win", proxytype, ip, port, userproxy, passproxy, "https://vnlogin.com");
            MessageBox.Show("Tạo thành công Profile có ID: " + id);

            //sau khi tạo mở profile và trả về PID để kill process
            string PID = VNLoginDLL.Open(Orbitar, id, proxytype, ip, port);
            MessageBox.Show("Mở thành công Profile có PID: " + PID);
        }

        private void btnmac_Click(object sender, EventArgs e)
        {
            string id = VNLoginDLL.Mac("vnlogin", "vnlogin", "Mac", "no", "", "", "", "", "https://vnlogin.com");
            MessageBox.Show("Tạo thành công Profile có ID: " + id);

            //sau khi tạo mở profile và trả về PID để kill process
            string PID = VNLoginDLL.Open(Orbitar, id, proxytype, ip, port);
            MessageBox.Show("Mở thành công Profile có PID: " + PID);
        }

        private void btnlinux_Click(object sender, EventArgs e)
        {
            string id = VNLoginDLL.Linux("vnlogin", "vnlogin", "Linux", "no", "", "", "", "", "https://vnlogin.com");
            MessageBox.Show("Tạo thành công Profile có ID: " + id);

            //sau khi tạo mở profile và trả về PID để kill process
            string PID = VNLoginDLL.Open(Orbitar, id, proxytype, ip, port);
            MessageBox.Show("Mở thành công Profile có PID: " + PID);
        }

        private void btnandroid_Click(object sender, EventArgs e)
        {
            string id = VNLoginDLL.Android("vnlogin", "vnlogin", "Android", "no", "", "", "", "", "https://vnlogin.com");
            MessageBox.Show("Tạo thành công Profile có ID: " + id);

            //sau khi tạo mở profile và trả về PID để kill process
            string PID = VNLoginDLL.Open(Orbitar, id, proxytype, ip, port);
            MessageBox.Show("Mở thành công Profile có PID: " + PID);
        }

        private void btniphone_Click(object sender, EventArgs e)
        {
            string id = VNLoginDLL.Iphone("vnlogin", "vnlogin", "Iphone", "no", "", "", "", "", "https://vnlogin.com");
            MessageBox.Show("Tạo thành công Profile có ID: " + id);

            //sau khi tạo mở profile và trả về PID để kill process
            string PID = VNLoginDLL.Open(Orbitar, id, proxytype, ip, port);
            MessageBox.Show("Mở thành công Profile có PID: " + PID);
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(delegate ()
            {
                try
                {
                    ZipFile.ExtractToDirectory(".\\data\\orbita-browser\\chrome.zip", ".\\data\\orbita-browser\\");
                }
                catch { }
            });
            thread.Start();
            
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

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

        #region B1 ĐĂNG KÝ ĐĂNG NHẬP
        /*
         * Chức năng đăng nhập:
         *      - Máy nào cũng có thể sử dụng phần mềm
         *      - Chỉ cần nhập đúng user và license key
         *      - Nhưng tại 1 thời điểm chỉ dùng được 1 máy
         */
        private void btnlogin_Click(object sender, EventArgs e)
        {
            string StatusLogin = VNLoginDLL.SignIn(txtUserLogin.Text, txtKeyLogin.Text);
            /*
             * Đăng nhập thành công:
             *      StatusLogin = "số ngày sử dụng License"
             * Đăng nhập thất bại:
             *      StatusLogin = er1 (lỗi quá giới hạn thiết bị được phép đăng nhập, chờ vài phút để session reset)
             *      StatusLogin = er2 (lỗi key không đúng)
             *      StatusLogin = er3 (lỗi user không tồn tại)
             */
            if (StatusLogin != "er1" && StatusLogin != "er2" && StatusLogin != "er3")
            {
                if (Convert.ToInt32(StatusLogin) < 0)
                {
                    MessageBox.Show(StatusLogin);
                    //hết hạn sử dụng
                }
                else
                {
                    MessageBox.Show(StatusLogin);
                    //đăng nhập thành công = Mở form Main
                }
            }
            else
            {
                MessageBox.Show(StatusLogin);
                //Thông báo lỗi
            }
        }
        #endregion

        #region B2 TẠO PROFILE

        string proxytype = "";
        string ip = "";
        string port = "";
        string userproxy = "c";
        string passproxy = "";
        string Orbitar = @"C:\Users\vodin\.gologin\browser\orbita-browser\";

        private void btnwin_Click(object sender, EventArgs e)
        {
            string statusNew = VNLoginDLL.Win("Win", proxytype, ip, port, userproxy, passproxy, "https://vnlogin.com");
            /*
             * Tạo Profile thành công:
             *      statusNew = "id Profile"
             * Tạo Profile thất bại:
             *      statusNew = er1 (lỗi quá giới hạn thiết bị được phép đăng nhập, chờ vài phút để session reset)
             *      statusNew = er2 (lỗi key không đúng)
             *      statusNew = er3 (lỗi user không tồn tại)
             *      statusNew = expired (lỗi hết hạn sử dụng key)
             */
            if (statusNew != "er1" && statusNew != "er2" && statusNew != "er3" && statusNew != "expired")
            {
                MessageBox.Show("Tạo thành công Profile có ID: " + statusNew);
                //sau khi tạo mở profile và trả về PID để kill process
                string PID = VNLoginDLL.Open(Orbitar, statusNew, proxytype, ip, port);
                MessageBox.Show("Mở thành công Profile có PID: " + PID);
            }    
            else
            {
                MessageBox.Show("Lỗi " + statusNew);
            }    
            

            
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

        #endregion

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            VNLoginDLL.UpdateNameProfile(txtID.Text, txtName.Text);


            //Mở profile để bạn kiểm tra. Khi viết tool bạn bỏ hàm này đi
            string PID = VNLoginDLL.Open(Orbitar, txtID.Text, "no", "", "");
            MessageBox.Show("Mở thành công Profile có PID: " + PID);
        }

        private void btnProxy_Click(object sender, EventArgs e)
        {
            string TypeProxy = "http";
            string IP = "";
            string Port = "";
            string UserIP = "";
            string PassIP = "";
            try
            {
                IP = txtProxy.Text.Split(':')[0];
            }
            catch { }
            try
            {
                Port = txtProxy.Text.Split(':')[1];
            }
            catch { }
            try
            {
                UserIP = txtProxy.Text.Split(':')[2];
            }
            catch { }
            try
            {
                PassIP = txtProxy.Text.Split(':')[3];
            }
            catch { }
            VNLoginDLL.Proxy(txtID.Text, TypeProxy, IP, Port, UserIP, PassIP);

            //Mở profile để bạn kiểm tra. Khi viết tool bạn bỏ hàm này đi
            string PID = VNLoginDLL.Open(Orbitar, txtID.Text, TypeProxy, IP, Port);
            MessageBox.Show("Mở thành công Profile có PID: " + PID);
        }

        private void btnUA_Click(object sender, EventArgs e)
        {
            VNLoginDLL.UpdateUA(txtID.Text, txtUA.Text);

            //Mở profile để bạn kiểm tra. Khi viết tool bạn bỏ hàm này đi
            string PID = VNLoginDLL.Open(Orbitar, txtID.Text, "no", "", "");
            MessageBox.Show("Mở thành công Profile có PID: " + PID);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            var FolderBackup = new FolderBrowserDialog();
            if (FolderBackup.ShowDialog() == DialogResult.OK)
            {
                string PathBackup = FolderBackup.SelectedPath;
                /*
                 * Backup Profile thất bại:
                 *      StatusBackup = er1 (lỗi quá giới hạn thiết bị được phép đăng nhập, chờ vài phút để session reset)
                 *      StatusBackup = er2 (lỗi key không đúng)
                 *      StatusBackup = er3 (lỗi user không tồn tại)
                 *      StatusBackup = expired (lỗi hết hạn sử dụng key)
                 */
                string StatusBackup = VNLoginDLL.BackupVNLogin(txtIDBackup.Text, PathBackup,true);
                if (StatusBackup != "er1" && StatusBackup != "er2" && StatusBackup != "er3" && StatusBackup != "expired")
                {
                    MessageBox.Show("Backup thành công Profile ID: " + txtIDBackup.Text);
                }    
                else
                {
                    MessageBox.Show("Lỗi " + StatusBackup);
                }    
                    
            }
        }
    }
}

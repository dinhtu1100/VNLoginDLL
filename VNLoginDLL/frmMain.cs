using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
using PuppeteerSharp;
using PuppeteerExtraSharp;
using OpenQA.Selenium.Support.UI;

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
        string Orbitar = @"C:\Users\vodin\Documents\Zalo Received Files\mulbrowser\";

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
            MessageBox.Show("Bạn tự viết theo mẫu Create Win nhé!");
        }

        private void btnlinux_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn tự viết theo mẫu Create Win nhé!");
        }

        private void btnandroid_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn tự viết theo mẫu Create Win nhé!");
        }

        private void btniphone_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn tự viết theo mẫu Create Win nhé!");
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
        private void btnRestore_Click(object sender, EventArgs e)
        {
            var FileBackup = new OpenFileDialog();
            if(FileBackup.ShowDialog() == DialogResult.OK)
            {
                string PathBackup = FileBackup.FileName;
                /*
                 * Backup Profile thất bại:
                 *      StatusBackup = er1 (lỗi quá giới hạn thiết bị được phép đăng nhập, chờ vài phút để session reset)
                 *      StatusBackup = er2 (lỗi key không đúng)
                 *      StatusBackup = er3 (lỗi user không tồn tại)
                 *      StatusBackup = expired (lỗi hết hạn sử dụng key)
                 */
                string StatusRestore = VNLoginDLL.RestoreVNLogin(PathBackup);
                if (StatusRestore != "er1" && StatusRestore != "er2" && StatusRestore != "er3" && StatusRestore != "expired")
                {
                    MessageBox.Show("Restore thành công");
                }
                else
                {
                    MessageBox.Show("Lỗi " + StatusRestore);
                }
            }
        }
        private void txtOpen_Click(object sender, EventArgs e)
        {
            //bạn phải có thông tin loại proxy, IP Proxy và Port trước đó đã add cho profile
            //data này bạn phải tự lưu trữ để mở profile cho chuẩn
            //mặc định mình đang để ko có proxy
            string PID = VNLoginDLL.Open(Orbitar, txtIDopen.Text, "no", "", "");
            MessageBox.Show("Mở thành công Profile có PID: " + PID);
        }

        ChromeDriver driver;
        ChromeOptions chromeOptions = new ChromeOptions();
        ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
        private void btnOpenRemote_Click(object sender, EventArgs e)
        {
            //bạn phải có thông tin loại proxy, IP Proxy và Port trước đó đã add cho profile
            //data này bạn phải tự lưu trữ để mở profile cho chuẩn
            //mặc định mình đang để ko có proxy
            string RemotePort = VNLoginDLL.OpenRemote(Orbitar, txtIDopenRemote.Text, "no", "", "");


            //Kết nối với selenium để điều khiển Port
            chromeDriverService.HideCommandPromptWindow = true;
            chromeOptions.DebuggerAddress = $"localhost:{RemotePort}";

            driver = new ChromeDriver(chromeDriverService, chromeOptions);
            driver.Url = "https://google.com";
            driver.Navigate();

            Thread.Sleep(500);
            driver
                .FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input"))
                .SendKeys("vnlogin");

            Thread.Sleep(500);
            driver
                .FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input"))
                .SendKeys(OpenQA.Selenium.Keys.Enter);

            Thread.Sleep(1000);
            driver
                .FindElement(By.XPath("/html/body/div[7]/div/div[11]/div/div[2]/div[2]/div/div/div[1]/div/div/div[1]/div/a/h3"))
                .Click();

            Thread.Sleep(3000);
            driver.Url = "https://youtube.com";
            driver.Navigate();

            Thread.Sleep(1000);
            driver
                .FindElement(By.XPath("/html/body/ytd-app/div[1]/div/ytd-masthead/div[3]/div[2]/ytd-searchbox/form/div[1]/div[1]/input"))
                .SendKeys("vnlogin");

            Thread.Sleep(1000);
            driver
                .FindElement(By.XPath("/html/body/ytd-app/div[1]/div/ytd-masthead/div[3]/div[2]/ytd-searchbox/form/div[1]/div[1]/input"))
                .SendKeys(OpenQA.Selenium.Keys.Enter);

            Thread.Sleep(1000);
            driver
                .FindElement(By.XPath("/html/body/ytd-app/div[1]/ytd-page-manager/ytd-search/div[1]/ytd-two-column-search-results-renderer/div/ytd-section-list-renderer/div[2]/ytd-item-section-renderer/div[3]/ytd-video-renderer[1]/div[1]/ytd-thumbnail/a/yt-img-shadow/img"))
                .Click();

            Thread.Sleep(3000);
            driver
                .FindElement(By.XPath("/html/body/ytd-app/div[1]/div/ytd-masthead/div[3]/div[3]/div[2]/ytd-button-renderer/a/tp-yt-paper-button"))
                .Click();


            

        }

        private void btnOpenSele_Click(object sender, EventArgs e)
        {
            chromeOptions.BinaryLocation = Orbitar + "\\chrome.exe";
            chromeDriverService.HideCommandPromptWindow = true;


            chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
            chromeOptions.AddExcludedArgument("enable-automation");
            chromeOptions.AddArguments("--disable-web-security");
            chromeOptions.AddArguments("--allow-running-insecure-content");


            //chromeOptions.AddArgument("--user-agent=Mozilla/5.0 (iPhone; CPU iPhone OS 15_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) CriOS/98.0.4758.85 Mobile/15E148 Safari/604.1");
            chromeOptions.AddArguments($@"user-data-dir={AppDomain.CurrentDomain.BaseDirectory}\\profile\\{txtOpenSele.Text}");

            driver = new ChromeDriver(chromeDriverService, chromeOptions);
            driver.Url = "https://google.com";
            driver.Navigate();

            Thread.Sleep(1000);
            driver
                .FindElement(By.XPath("/html/body/div[1]/div[1]/div/div/div/div[2]/a"))
                .Click();

            Thread.Sleep(1000);
            string userMail = "vodinhtu.com@gmail.com";

            foreach (char letter in userMail)
            {
                driver
                .FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div/c-wiz/div/div[2]/div/div[1]/div/form/span/section/div/div/div[1]/div/div[1]/div/div[1]/input"))
                .SendKeys(letter.ToString());

                System.Threading.Thread.Sleep(300);
            }

            //Thread.Sleep(1000);
            //driver
            //    .FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div/div[2]/div/div/div[2]/div/div[1]/div/form/span/section/div/div/div[1]/div/div[1]/div/div[1]/input"))
            //    .SendKeys("vodinhtu.com@gmail.com");

            Thread.Sleep(1000);
            driver
                .FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div/c-wiz/div/div[2]/div/div[1]/div/form/span/section/div/div/div[1]/div/div[1]/div/div[1]/input"))
                .SendKeys(OpenQA.Selenium.Keys.Enter);
        }

       
    }
}

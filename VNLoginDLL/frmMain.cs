using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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

        private void btnwin_Click(object sender, EventArgs e)
        {
            VNLoginDLL.CreateWin(txtid1.Text, txtname.Text, txtproxy1.Text);
        }

        private void btnmac_Click(object sender, EventArgs e)
        {
            VNLoginDLL.CreateMac(txtid1.Text, txtname.Text, txtproxy1.Text);
        }

        private void btnlinux_Click(object sender, EventArgs e)
        {
            VNLoginDLL.CreateLinux(txtid1.Text, txtname.Text, txtproxy1.Text);
        }

        private void btnandroid_Click(object sender, EventArgs e)
        {
            VNLoginDLL.CreateAndroid(txtid1.Text, txtname.Text, txtproxy1.Text);
        }

        private void btniphone_Click(object sender, EventArgs e)
        {
            VNLoginDLL.CreateIphone(txtid1.Text, txtname.Text, txtproxy1.Text);
        }

        private void btnsetproxy_Click(object sender, EventArgs e)
        {
            VNLoginDLL.SetProxy(txtid2.Text, txtproxy2.Text);
        }

        private void btnbackup_Click(object sender, EventArgs e)
        {
            VNLoginDLL.Backup(txtid3.Text, txtbackup.Text);
        }
    }
}

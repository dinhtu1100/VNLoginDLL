using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNLoginDLL
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            if(VNLoginDLL.DangKy(txtuser.Text, txtpass.Text,txtgmail.Text,txtlicense.Text) == true)
            {
                MessageBox.Show("Đăng ký thành công, nhấn đăng nhập");
            }    
        }

        private void btndangky_Click(object sender, EventArgs e)
        {
            if (VNLoginDLL.DangNhap(txtuser.Text, txtpass.Text) == true)
            {
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();
            }
        }
    }
}

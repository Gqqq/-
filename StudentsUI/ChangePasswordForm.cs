using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Model;
using BLL;

namespace StudentsUI
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }
        AdminInfoModel adminmodel = new AdminInfoModel();
        AdminInfoBLL admin = new AdminInfoBLL();
        private void button1_Click(object sender, EventArgs e)
        {
            
            string oldpass = this.txtPass.Text.Trim();
            string newpass = this.newPass.Text.Trim();
            string repass = this.txtRepass.Text.Trim();
            if (newpass != repass)
            {
                MessageBox.Show("两次密码不一致");
                return;
            }
            //AdminInfoModel adminmodel = new AdminInfoModel();
            //AdminInfoBLL admin=new AdminInfoBLL ();
            //adminmodel.Admin_Password = oldpass;
            //MainForm m = (MainForm)this.Owner;
            //int a = m.adminid;
            //adminmodel.Admin_ID =m.adminid;

            //bool b = admin.CheckOldPass(adminmodel);//检查旧密码是否正确
            //if(b==false)
            //{
            //    MessageBox.Show("原始密码错误");
            //    return;
            //}
            //AdminInfoModel model = new AdminInfoModel();
            //model.Admin_ID = m.adminid;
            //model.Admin_Password = newpass;
            //admin.UpdateAdminInfo(adminmodel);
            MainForm m = (MainForm)this.Owner;
            int a = m.adminid;
            adminmodel.Admin_ID = a;
            adminmodel.Admin_Password = oldpass;
            bool b = admin.CheckOldPass(adminmodel);
            if (b == false)
            {
                MessageBox.Show("原密码错误");
                return;
            }
            AdminInfoModel model = new AdminInfoModel();
            adminmodel.Admin_ID = m.adminid;
            adminmodel.Admin_Password = newpass;
            admin.UpdateAdminInfo(adminmodel);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using System.Data.SqlClient;
using BLL;

namespace StudentsUI
{
    public partial class UserManageForm : Form
    {
        AdminInfoBLL admin = new AdminInfoBLL();
        AdminInfoModel adminmodel = new AdminInfoModel();
        public UserManageForm()
        {
            InitializeComponent();
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            string name = this.txtAdminName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("管理员姓名不能为空");
                return;
            }
            string pass = this.txtPassword.Text.Trim();
            string pass2 = this.txtPassword2.Text.Trim();
            string level = this.cmbLevel.SelectedItem.ToString();
            if (pass != pass2)
            {
                MessageBox.Show("两次密码输入不一致");
                return;
            }
            adminmodel.Admin_Name = name;
            adminmodel.Admin_Password = pass;
            adminmodel.Admin_Level = level;

            bool b = admin.CheckAdminInfo(adminmodel);
            if (b == true)
            {
                MessageBox.Show("该管理员已存在");
                return;
            }
            admin.AddAdminInfo(adminmodel);
            BindAdmin();
        }
        void BindAdmin()
        {
            this.dataGridView1.DataSource = admin.GetAllAdminInfo(adminmodel);
        }
        
        private void UserManageForm_Load(object sender, EventArgs e)
        {
            BindAdmin();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            AdminInfoBLL admin = new AdminInfoBLL();
            AdminInfoModel adminmodel = new AdminInfoModel();
            string id = this.dataGridView1.SelectedRows[0].Cells["管理员编号"].Value.ToString();
            //adminmodel.Admin_ID = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["管理员编号"].Value);
            string name=this.dataGridView1.SelectedRows[0].Cells["管理员权限"].Value.ToString();
            //admin.DelAdminInfo(adminmodel);
            if (name != "超级管理员")
            {
                adminmodel.Admin_ID = Convert.ToInt32(id);
                admin.DelAdminInfo(adminmodel);
                BindAdmin();
            }
            else
            {
                MessageBox.Show("不能删除超级管理员");
                return;
            }
            
        }
    }
}

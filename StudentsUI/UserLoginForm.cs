using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;
using System.Data.SqlClient;

namespace StudentsUI
{
    
    public partial class UserLoginForm : Form
    {
        bool islog = false;
        string Ccode="";
        public UserLoginForm()
        {
            InitializeComponent();
        }
        string CreateCode(int length)
        {
            string code = "";//验证字符串
            string str = "OPQRST01234ABCD56789abcdeEFGHIfghijkU12390VWXYZlmno45678pqJKLMNrstuvwxyz";
            Random r = new Random();
            //循环产生指定个数的随机字符
            for (int i = 1; i <= length; i++)
            {
                int j = r.Next(0, str.Length - 1);

                code += str[j];
            }

            return code;
        }
        void CreateImage()
        {

            Bitmap bp = new Bitmap(120, 45);
            Graphics g = Graphics.FromImage(bp);

             Ccode = CreateCode(4);//调用方法获取随机符串
            Random r = new Random();

            SolidBrush s = new SolidBrush(Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256)));
            Font f = new Font("Arial", 16f, FontStyle.Italic | FontStyle.Bold);
            Pen p = new Pen(Color.Silver);//银色画笔
            //循环设置200个随机像素点（干扰点）
            for (int i = 0; i < 300; i++)
            {
                int x = r.Next(0, bp.Width);//随机产生像素点的X坐标
                int y = r.Next(0, bp.Height);//随机产生像素点的Y坐标
                int red = r.Next(0, 256);//随机产生红色
                int green = r.Next(0, 256);//随机产生绿色
                int blue = r.Next(0, 256);//随机产生蓝色
                bp.SetPixel(x, y, Color.FromArgb(red, green, blue));//设置像素点
            }
            //随机画10条干扰线
            for (int i = 1; i <= 10; i++)
            {
                g.DrawLine(p, new Point(r.Next(0, bp.Width), r.Next(0, bp.Height)), new Point(r.Next(0, bp.Width), r.Next(0, bp.Height)));
            }
            //分开画验证字符，给每个字符随机不同坐标
            int y1 = r.Next(0, 25);
            g.DrawString(Ccode[0].ToString(), f, s, r.Next(0, bp.Width / Ccode.Length - 20), y1);
            g.DrawString(Ccode[1].ToString(), f, s, r.Next(bp.Width / Ccode.Length, bp.Width / Ccode.Length * 2 - 20), y1);
            g.DrawString(Ccode[2].ToString(), f, s, r.Next(bp.Width / Ccode.Length * 2, bp.Width / Ccode.Length * 3 - 20), y1);
            g.DrawString(Ccode[3].ToString(), f, s, r.Next(bp.Width / Ccode.Length * 3, bp.Width - 20), y1);

            g.DrawRectangle(p, new Rectangle(0, 0, bp.Width - 1, bp.Height - 1));//画外框
            this.pictureBox1.Image = bp;

        }

        /// <summary>
        /// 管理员权限登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string name = this.txtName.Text.Trim();
            string pass = this.txtPass.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请输入姓名");
                return;
            }
            if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("请输入密码");
                return;
            }
            if (this.textBox1.Text.ToLower() != Ccode.ToLower())
            {
                CreateImage();
                MessageBox.Show("验证码输入错误");
                return;
            }
            //学生登陆
            StudentsModel stumodel = new StudentsModel();
            StudentsBLL student = new StudentsBLL();
            if (this.checkBox1.Checked)
            {
                stumodel.Student_Name = this.txtName.Text;
                try
                {
                    DataRow row = student.GetStudentByName(stumodel).Rows[0];

                    string num = row["StudentNum"].ToString().Substring(10, 4);
                    string cnum = this.txtPass.Text;
                    if (num == cnum)
                    {
                        int id = Convert.ToInt32(row["Student_ID"]);
                        PropertyForm fm = new PropertyForm(id);
                        fm.Show();
                    }
                    else
                    {

                        MessageBox.Show("用户名或密码错误");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("用户名或密码不匹配");
                }
            }
            else
            {
                AdminInfoModel adminmodel = new AdminInfoModel();
                AdminInfoBLL admininfo = new AdminInfoBLL();
                adminmodel.Admin_Name = name;
                adminmodel.Admin_Password = pass;
                SqlDataReader dr = admininfo.AdminLogin(adminmodel);
                if (dr.Read())//如果登陆成功
                {
                    MainForm main = (MainForm)this.Owner;//实例化主窗体
                    //将管理员的ID和权限保存到主窗体全局字段
                    main.adminid = Convert.ToInt32(dr["Admin_ID"]);
                    main.level = dr["Admin_Level"].ToString();
                    islog = true;//将是否登陆成功的标识改为true
                    dr.Close();//关闭阅读器
                    this.Close();//关闭主窗体
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("用户名或密码错误");
                    return;
                }
            }
        }
        //修复的小BUG
        private void UserLoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (islog == false)
            {
                System.Environment.Exit(0);
            }
        }
        /// <summary>
        /// 回车登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(sender, e);
            }
        }

        private void UserLoginForm_Load(object sender, EventArgs e)
        {
            CreateImage();
            //this.skinEngine1.SkinFile = "VS2008皮肤\\MSN.ssk";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateImage();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(sender, e);
            }
        }
        /// <summary>
        /// 登陆页面关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://baidu.com");
        }
    }
}

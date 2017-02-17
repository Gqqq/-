using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;

namespace StudentsUI
{
    public partial class SetSubject : Form
    {
        string College;//专业所属学院
        string Speciality;//专业名称
        string Speciality_ID;//专业编号

        #region 利用构造函数初始化对象
        /// <summary>
        /// 利用构造函数初始化对象
        /// </summary>
        /// <param name="coll">专业所属学院</param>
        /// <param name="spe">专业名称</param>
        /// <param name="spe_ID">专业编号</param>
        public SetSubject(string coll,string spe,string spe_ID)
        {
            this.College = coll;
            this.Speciality = spe;
            this.Speciality_ID = spe_ID;
            InitializeComponent();
        }
        #endregion

        #region 创建查询所有科目的方法
        void GetAllSubject()
        {
            SubjectsBLL Subject = new SubjectsBLL();
            this.comboBox1.DisplayMember = "科目名称";
            this.comboBox1.ValueMember = "科目编号";
            this.comboBox1.DataSource = Subject.GetAllSubjects();
        }
        void GetAllSepc_Subjects()
        {
            Sepc_SubjectsBLL Sepc_Subjects = new Sepc_SubjectsBLL();
            Sepc_SubjectsModel model = new Sepc_SubjectsModel();
            model.Sepc_ID = Speciality_ID;
            dataGridView1.DataSource = Sepc_Subjects.GetAllSepc_Subjects(model);
        }
        #endregion

        #region 窗体加载事件
        private void SetSubject_Load(object sender, EventArgs e)
        {
            
            GetAllSubject();
            this.Text = "为" + Speciality + "专业设置学科";
            this.lblname.Text = College + "——" + Speciality;
            GetAllSepc_Subjects();
        }
        #endregion

        #region 为专业添加学科
        private void button1_Click(object sender, EventArgs e)
        {
            Sepc_SubjectsBLL Sepc_Subjects = new Sepc_SubjectsBLL();
            Sepc_SubjectsModel model = new Sepc_SubjectsModel();
            model.Sepc_ID = Speciality_ID;
            model.Subjects_ID =Convert.ToInt32(this.comboBox1.SelectedValue);
            bool b = Sepc_Subjects.SeleSepc_Subjects(model);
            if (b == true)
            {
                MessageBox.Show("该专业下已经存在该科目，请重新选择");
                return;
            }
            Sepc_Subjects.AddSepc_Subjects(model);
            GetAllSepc_Subjects();
        }
        #endregion

        #region 删除专业下的学科
        private void button2_Click(object sender, EventArgs e)
        {
            Sepc_SubjectsBLL Sepc_Subjects = new Sepc_SubjectsBLL();
            Sepc_SubjectsModel model = new Sepc_SubjectsModel();
            model.Sepc_ID = Speciality_ID;
            model.Subjects_ID = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["学科编号"].Value);
            Sepc_Subjects.DeleSepc_Subjects(model);
            GetAllSepc_Subjects();
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

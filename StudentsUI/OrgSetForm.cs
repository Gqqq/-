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
    public partial class OrgSetForm : Form
    {

        public OrgSetForm()
        {
            InitializeComponent();
        }
        #region 学科
        #region 创建查询所有学科的方法
        /// <summary>
        /// 创建查询所有学科的方法
        /// </summary>
        void GetAllSubject()
        {
            SubjectsBLL subject = new SubjectsBLL();
            dataxueke.DataSource = subject.GetAllSubjects();
        }
        #endregion

        #region 添加科目的方法
        private void btnAddke_Click(object sender, EventArgs e)
        {
            SubjectsBLL subject = new SubjectsBLL();
            SubjectsModel model = new SubjectsModel();
            if (string.IsNullOrEmpty(this.txtkeName.Text))
            {
                MessageBox.Show("学科名称不能为空");
                return;
            }
            model.Subjects_Name = this.txtkeName.Text;
            subject.AddSubjects(model);
            GetAllSubject();
        }
        #endregion

        #region 删除科目的方法
        private void benDeleke_Click(object sender, EventArgs e)
        {
            SubjectsBLL subject = new SubjectsBLL();
            SubjectsModel model = new SubjectsModel();
            if (this.dataxueke.SelectedRows.Count > 0)
            {
                int ID = Convert.ToInt32(this.dataxueke.SelectedRows[0].Cells["科目编号"].Value);
                model.Subjects_ID = ID;
                try
                {
                    subject.DeleSubjects(model);
                    GetAllSubject();
                }
                catch
                {
                    MessageBox.Show("删除失败");
                }
                
            }
        }
        #endregion
        #endregion

        #region 专业

        #region 专业外键方法
        void GetAllCollege()
        {
            SpeYearsBLL year = new SpeYearsBLL(); 
            CollegesBLL college = new CollegesBLL();
            DataTable dt = college.GetAllColleges();
            cmdyuanName.DisplayMember = "学院名称";
            cmdyuanName.ValueMember = "学院编号";
            cmdyuanName.DataSource = dt;
            DataTable ydt = year.GetAllSpeYears();
            cmdxuezhi.DisplayMember = "学制名称";
            cmdxuezhi.ValueMember = "学制编号";
            cmdxuezhi.DataSource = ydt;
        }
        #endregion

        #region 添加专业的方法
        private void btnAddzhuan_Click(object sender, EventArgs e)
        {
            SpecialityBLL Speciality = new SpecialityBLL();
            SpecialityModel model = new SpecialityModel();
            model.Speciality_ID = lblCollegeId.Text + this.txtzhuanbian.Text;
            bool b = Speciality.SeleSpeciality(model);
            if (b == true)
            {
                MessageBox.Show("编号已存在，请重新输入");
                this.txtzhuanbian.Text = "";
                return;
            }
            if (string.IsNullOrEmpty(this.txtzhuanbian.Text))
            {
                MessageBox.Show("专业编号不能为空");
                return;
            }
            if (this.txtzhuanbian.Text.Length != 2)
            {
                MessageBox.Show("专业编号必须两位");
                this.txtzhuanbian.Text = "";
                return;
            }
            if (string.IsNullOrEmpty(this.txtzhuanName.Text))
            {
                MessageBox.Show("专业名称不能为空");
                return;
            }
            
            model.Speciality_Name =this.txtzhuanName.Text;
            model.Speciality_College = this.cmdyuanName.SelectedValue.ToString();
            model.Speciality_Years =Convert.ToInt32(this.cmdxuezhi.SelectedValue);
            Speciality.AddSpeciality(model);
            GetAllSpeciality();
        }
        #endregion

        #region 专业lbl
        private void cmdyuanName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblCollegeId.Text = cmdyuanName.SelectedValue.ToString();
        }
        #endregion

        #region 查询所有专业信息的方法
        void GetAllSpeciality()
        {
            SpecialityBLL Speciality = new SpecialityBLL();
            datazhuan.DataSource=Speciality.GetAllSpeciality();
        }
        #endregion

        #region 删除专业信息
        private void btnDelezhuan_Click(object sender, EventArgs e)
        {
            SpecialityBLL Speciality = new SpecialityBLL();
            SpecialityModel model = new SpecialityModel();
            model.Speciality_ID = this.datazhuan.SelectedRows[0].Cells["专业编号"].Value.ToString();
            try
            {
                Speciality.DeleSpeciality(model);
                GetAllSpeciality();
            }
            catch
            {
                MessageBox.Show("删除失败");
            }
            
        }
        #endregion

        #region 修改专业信息的方法

        #region 控件选项发生改变时
        private void datazhuan_SelectionChanged(object sender, EventArgs e)
        {
            if (this.datazhuan.SelectedRows.Count > 0)
            {
                cmdyuanName.Text = datazhuan.SelectedRows[0].Cells["所属学院"].Value.ToString();
                txtzhuanbian.Text = datazhuan.SelectedRows[0].Cells["专业编号"].Value.ToString().Substring(2);
                txtzhuanName.Text = datazhuan.SelectedRows[0].Cells["专业名称"].Value.ToString();
                cmdxuezhi.Text = datazhuan.SelectedRows[0].Cells["学制"].Value.ToString();
            }
        }
        #endregion

        private void btnUPzhuan_Click(object sender, EventArgs e)
        {
            SpecialityBLL Speciality = new SpecialityBLL();
            SpecialityModel model = new SpecialityModel();
            model.Speciality_Name = txtzhuanName.Text;
            model.Speciality_Years =Convert.ToInt32(cmdxuezhi.SelectedValue);
            model.Speciality_ID = datazhuan.SelectedRows[0].Cells["专业编号"].Value.ToString();
            Speciality.UPSpeciality(model);
            GetAllSpeciality();
        }
        #endregion

        #region 按照编号查询专业信息
        private void button5_Click(object sender, EventArgs e)
        {
            SpecialityBLL Speciality = new SpecialityBLL();
            SpecialityModel model = new SpecialityModel();
            model.Speciality_ID = "%"+txtzhuanchaname.Text+"%";
            model.Speciality_Name = "%" + txtzhuanchaname.Text + "%";
            if (this.cmbchalei.SelectedIndex==0)
            {
                datazhuan.DataSource = Speciality.GetIdSpeciality(model);
            }
            else
            {
                datazhuan.DataSource = Speciality.GetNameSpeciality(model);
            }
        }
        #endregion

        #region 为专业设置学科
        private void button4_Click(object sender, EventArgs e)
        {
            string coll = this.datazhuan.SelectedRows[0].Cells["所属学院"].Value.ToString();
            string spe = this.datazhuan.SelectedRows[0].Cells["专业名称"].Value.ToString();
            string spe_ID = this.datazhuan.SelectedRows[0].Cells["专业编号"].Value.ToString();
            SetSubject set = new SetSubject(coll, spe, spe_ID);
            set.Owner = this;
            set.Show();
        }
        #endregion

        #endregion

        #region 选项卡Selecting事件，根据索引改变dataGridView中所绑定的值
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Text == "学科设置")
            {
                GetAllSubject();
            }
            else if (e.TabPage.Text == "学制设置")
            {
                GetAllSpeYear();
            }
            else if (e.TabPage.Text == "学院设置")
            {
                this.cmdName.SelectedIndex = 0;
                GetAllColleges();
            }
            else if (e.TabPage.Text == "专业设置")
            {
                GetAllCollege();
                GetAllSpeciality();
                this.cmbchalei.SelectedIndex = 0;
            }
            else if (e.TabPage.Text == "班主任设置")
            {
               this.cmbbansex.SelectedIndex = 0;
                GetAllTeacher();
            }
            else if (e.TabPage.Text == "班级设置")
            {
               
                Getyuan();
                GetBan();
                GetAllClass();
            }
        }
        #endregion

        #region 窗体加载事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrgSetForm_Load(object sender, EventArgs e)
        {
            this.cmdName.SelectedIndex = 0;
            GetAllColleges();
            
        }
        #endregion

        #region 学制
        #region 创建查询所有学制的方法
        void GetAllSpeYear()
        {
            SpeYearsBLL SpeYear = new SpeYearsBLL();
            dataxuezhi.DataSource = SpeYear.GetAllSpeYears();
        }
        #endregion

        #region 添加学制的方法
        /// <summary>
        /// 添加学制的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddxue_Click(object sender, EventArgs e)
        {
            SpeYearsModel model = new SpeYearsModel();
            SpeYearsBLL SpeYear = new SpeYearsBLL();
            
            if (string.IsNullOrEmpty(this.txtXueName.Text))
            {
                MessageBox.Show("学制名称不能为空");
                return;
            }
            if (string.IsNullOrEmpty(this.txtXueTime.Text))
            {
                MessageBox.Show("学制时间不能为空");
                return;
            }

            model.SpeYears_Name = this.txtXueName.Text;
            try
            {
                model.SpeYears_Years = Convert.ToInt32(this.txtXueTime.Text);
            }
            catch
            {
                MessageBox.Show("学制时间只能是正整数");
                this.txtXueTime.Text=null;
                return;
            }
            SpeYear.AddSpeYears(model);
            GetAllSpeYear();
        }
        #endregion

        #region 删除学制的方法
        private void btndeletexue_Click(object sender, EventArgs e)
        {
            SpeYearsModel model = new SpeYearsModel();
            SpeYearsBLL SpeYear = new SpeYearsBLL();
            if (this.dataxuezhi.SelectedRows.Count > 0)
            {
                int ID = Convert.ToInt32(this.dataxuezhi.SelectedRows[0].Cells["学制编号"].Value);
                model.SpeYears_ID = ID;
                try
                {
                    SpeYear.DeleSpeYears(model);
                    GetAllSpeYear();
                }
                catch
                {
                    MessageBox.Show("删除失败");
                }
                
            }

        }
        #endregion
        #endregion

        #region 学院

        #region 检测学院
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CollegesBLL college = new CollegesBLL();
            CollegesModel model = new CollegesModel();
            if (this.txtyuanbian.TextLength != 2)
            {
                MessageBox.Show("学院编号只能为两位");
                this.txtyuanbian.Text = "";
                return;
            }
            model.College_ID = this.txtyuanbian.Text;
           bool b= college.SeleColleges(model);
           if (b == true)
           {
               MessageBox.Show("编号已存在，请重新输入");
               this.txtyuanbian.Text = "";
               return;
           }
        }
        #endregion

        #region 添加学院
        private void btnAddyuan_Click(object sender, EventArgs e)
                {
                    CollegesBLL college = new CollegesBLL();
                    CollegesModel model = new CollegesModel();
                    if (this.txtyuanbian.TextLength != 2)
                    {
                        MessageBox.Show("学院编号只能为两位");
                        this.txtyuanbian.Text = "";
                        return;
                    }
                    model.College_ID = this.txtyuanbian.Text;
                    bool b = college.SeleColleges(model);
                    if (b == true)
                    {
                        MessageBox.Show("编号已存在，请重新输入");
                        this.txtyuanbian.Text = "";
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtyuanbian.Text))
                    {
                        MessageBox.Show("学院编号不能为空");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtyuanName.Text))
                    {
                        MessageBox.Show("学院名称不能为空");
                        return;
                    }
                    try
                    {
                        model.College_ID = this.txtyuanbian.Text;
                    }
                    catch
                    {
                        MessageBox.Show("学院编号重复");
                        this.txtyuanbian.Text = "";
                    }
                    model.College_Name = this.txtyuanName.Text;
                    college.AddColleges(model);
                    GetAllColleges();
                }
        #endregion

        #region 查询所有学院信息方法
        void GetAllColleges()
        {
            CollegesBLL college = new CollegesBLL();
            datayuan.DataSource = college.GetAllColleges();
        }
        #endregion

        #region 删除学院信息
        private void btnyuandele_Click(object sender, EventArgs e)
        {
            CollegesBLL college = new CollegesBLL();
            CollegesModel model = new CollegesModel();
            if (this.datayuan.SelectedRows.Count > 0)
            {
                string ID = this.datayuan.SelectedRows[0].Cells["学院编号"].Value.ToString();
                model.College_ID = ID;
                try
                {
                    college.DeleColleges(model);
                    GetAllColleges();
                }
                catch
                {
                    MessageBox.Show("删除失败");
                }
            }
            
        }
        #endregion

        #region 修改学院信息
        private void btnyuanUpdate_Click(object sender, EventArgs e)
        {
            CollegesBLL college = new CollegesBLL();
            CollegesModel model = new CollegesModel();
            if (this.datayuan.SelectedRows.Count > 0)
            {
                string ID = this.datayuan.SelectedRows[0].Cells["学院编号"].Value.ToString();
                string name = this.datayuan.SelectedRows[0].Cells["学院名称"].Value.ToString();
                model.College_ID = ID;
                model.College_Name = name;
                college.UPColleges(model);
                GetAllColleges();
            }
        }


        #endregion

        #region 按照学院编号查询
        private void btnseleyuan_Click(object sender, EventArgs e)
        {
            CollegesBLL college = new CollegesBLL();
            CollegesModel model = new CollegesModel();
            if (this.cmdName.SelectedItem.ToString() == "按照编号")
            {
                model.College_ID ="%"+this.txtchaname.Text+"%";
              DataTable dt=college.GetIDColleges(model);
              datayuan.DataSource = dt;
            }
            else if (this.cmdName.SelectedItem.ToString() == "按照名称")
            {
                model.College_Name = "%" + this.txtchaname.Text + "%";
                DataTable dt = college.GetNameColleges(model);
                datayuan.DataSource = dt;
            }
        }
        #endregion

        #endregion

        #region 班主任

        #region 修改绑定
        void Bangd()
        {
            if (this.databanzhuren.SelectedRows.Count > 0)
            {
                this.txtbanName.Text = databanzhuren.SelectedRows[0].Cells["教师姓名"].Value.ToString();
                this.txtbanTel.Text = databanzhuren.SelectedRows[0].Cells["教师电话"].Value.ToString();
                this.cmbbansex.SelectedItem = databanzhuren.SelectedRows[0].Cells["教师性别"].Value.ToString();
                this.daTimeru.Value = Convert.ToDateTime(databanzhuren.SelectedRows[0].Cells["入职日期"].Value);
                this.daTimechu.Value = Convert.ToDateTime(databanzhuren.SelectedRows[0].Cells["教师生日"].Value);
                this.txtdidian.Text = databanzhuren.SelectedRows[0].Cells["教师籍贯"].Value.ToString();
            }
        }
        #endregion

        #region 当控件发生改变时
        private void databanzhuren_SelectionChanged(object sender, EventArgs e)
        {
            Bangd();
        }
        #endregion

        #region 查询所有教师信息
        void GetAllTeacher()
        {
            TeacherBLL teacher = new TeacherBLL();
            databanzhuren.DataSource = teacher.GetAllTeacher();
        }
        #endregion

        #region 添加教师信息
        private void btnAddban_Click(object sender, EventArgs e)
        {
            TeacherBLL teacher = new TeacherBLL();
            TeachersModel model = new TeachersModel();
            if (string.IsNullOrEmpty(txtbanName.Text))
            {
                MessageBox.Show("班主姓名不能为空");
                this.txtbanName.Text = "";
                return;
            }
            if (string.IsNullOrEmpty(txtbanTel.Text))
            {
                MessageBox.Show("班主电话不能为空");
                this.txtbanTel.Text = "";
                return;
            }
            if (txtbanTel.Text.Length != 11)
            {
                MessageBox.Show("手机号必须11位");
            }
            if (string.IsNullOrEmpty(txtdidian.Text))
            {
                MessageBox.Show("班主籍贯不能为空");
                this.txtdidian.Text = "";
                return;
            }
            model.Teacher_Name = this.txtbanName.Text;
            model.Teacher_Tel = this.txtbanTel.Text;
            model.Teacher_Sex = this.cmbbansex.SelectedItem.ToString();
            model.Teacher_InDate = this.daTimeru.Value;
            model.Teacher_Birthday = this.daTimechu.Value;
            model.Teacher_Origin = this.txtdidian.Text;
            teacher.AddTeacher(model);
            GetAllTeacher();
        }
        #endregion

        #region 删除教师信息
        private void btnDeleban_Click(object sender, EventArgs e)
        {
            TeacherBLL teacher = new TeacherBLL();
            TeachersModel model = new TeachersModel();
            model.Teacher_ID =Convert.ToInt32(databanzhuren.SelectedRows[0].Cells["教师编号"].Value);
            teacher.DeleTeacher(model);
            GetAllTeacher();
        }
        #endregion

        #region 修改教师信息
        private void btnUPban_Click(object sender, EventArgs e)
        {
            TeacherBLL teacher = new TeacherBLL();
            TeachersModel model = new TeachersModel();
            model.Teacher_ID =Convert.ToInt32(this.databanzhuren.SelectedRows[0].Cells["教师编号"].Value);
            model.Teacher_Name = this.txtbanName.Text;
            model.Teacher_Tel = this.txtbanTel.Text;
            model.Teacher_Sex = this.cmbbansex.SelectedItem.ToString();
            model.Teacher_InDate = this.daTimeru.Value;
            model.Teacher_Birthday = this.daTimechu.Value;
            model.Teacher_Origin = this.txtdidian.Text;
            teacher.UPTeacher(model);
            GetAllTeacher();
        }
        #endregion

        #region 清空按键
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.txtbanName.Text = "";
            this.txtbanTel.Text = "";
            this.cmbbansex.SelectedIndex = 0;

            this.txtdidian.Text = "";
        }
        #endregion

        #endregion

        #region //班级

        #region 创建选项发生改变事件
        void Getyuan()
        {
            CollegesBLL college = new CollegesBLL();
            this.cmbyuan.DisplayMember = "学院名称";
            this.cmbyuan.ValueMember = "学院编号";
            this.cmbyuan.DataSource= college.GetAllColleges();
        }
        private void cmbyuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            SpecialityBLL Speciality = new SpecialityBLL();
            SpecialityModel model = new SpecialityModel();
            model.Speciality_ID = "%" + this.cmbyuan.SelectedValue.ToString() + "%";
            cmbzhuan.DisplayMember = "专业名称";
            cmbzhuan.ValueMember = "专业编号";
            cmbzhuan.DataSource = Speciality.GetIdSpeciality(model);
            
        }
        #endregion

        #region 专业发生改变时
        void GetBan()
        {
            TeacherBLL Teacher = new TeacherBLL();
            cmbbanname.DisplayMember = "教师姓名";
            cmbbanname.ValueMember = "教师编号";
            cmbbanname.DataSource=Teacher.GetAllTeacher();
        }
        private void cmbzhuan_SelectedIndexChanged(object sender, EventArgs e)
        {
             this.lblyy.Text = cmbzhuan.SelectedValue.ToString();
        }
        #endregion

        #region 添加班级
        private void benAddji_Click(object sender, EventArgs e)
        {
            ClassesBLL Class = new ClassesBLL();
            ClassesModel model = new ClassesModel();
            model.Classes_ID = lblyy.Text + txtjibian.Text;
            bool b= Class.SeleClasses(model);
            if (b == true)
            {
                MessageBox.Show("该班级编号已经存在，请重新输入");
                txtjibian.Text = "";
                return;
            }
            model.Classes_Name = txtjiname.Text;
            model.Classes_Speciality = cmbzhuan.SelectedValue.ToString();
            model.ClassHeadTeacher =Convert.ToInt32(cmbbanname.SelectedValue);
            Class.AddClasses(model);
            GetAllClass();

        }
        #endregion

        #region 绑定班级
        void GetAllClass()
        { 
            ClassesBLL Class=new ClassesBLL();
            this.dataGridView1.DataSource = Class.GetAllClasses();

        }
        #endregion

        #region 删除班级
        private void benDeleji_Click(object sender, EventArgs e)
        {
            ClassesBLL Class = new ClassesBLL();
            ClassesModel model = new ClassesModel();
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                model.Classes_ID = this.dataGridView1.SelectedRows[0].Cells["班级编号"].Value.ToString();
                Class.DeleClasses(model);
                GetAllClass();
            }
        }
        #endregion

        #region 控件选项发生改变时
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                this.txtjibian.Text = this.dataGridView1.SelectedRows[0].Cells["班级编号"].Value.ToString().Substring(4);
                this.cmbyuan.SelectedValue = this.dataGridView1.SelectedRows[0].Cells["班级编号"].Value.ToString().Substring(0, 2);
                this.cmbzhuan.Text = this.dataGridView1.SelectedRows[0].Cells["所属专业"].Value.ToString();
                this.txtjiname.Text = this.dataGridView1.SelectedRows[0].Cells["班级名称"].Value.ToString();
                this.cmbbanname.Text= this.dataGridView1.SelectedRows[0].Cells["班主任"].Value.ToString();

            }
        }
        #endregion

        #region 修改班级
        private void benUPji_Click(object sender, EventArgs e)
        {
            ClassesBLL Class = new ClassesBLL();
            ClassesModel model = new ClassesModel();
            model.Classes_Name = this.txtjiname.Text;
            model.ClassHeadTeacher =Convert.ToInt32(this.cmbbanname.SelectedValue);
            model.Classes_ID = this.dataGridView1.SelectedRows[0].Cells["班级编号"].Value.ToString();
            Class.UPClasses(model);
            GetAllClass();
        }
        #endregion

        #region 清空
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.txtjibian.Text = "";
            this.txtjiname.Text = "";
        }
        #endregion

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}

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

namespace StudentsUI
{
    public partial class AddStudentsForm : Form
    {
        CollegesBLL college = new CollegesBLL();//学院对象

        SpeYearsBLL speyear = new SpeYearsBLL();//学制业务对象
        SpeYearsModel spemodel = new SpeYearsModel();
        SpecialityBLL spec = new SpecialityBLL();//专业业务对象
        SpecialityModel specmodel = new SpecialityModel();
        ClassesBLL classes = new ClassesBLL();//班级业务对象
        ClassesModel classmodel = new ClassesModel();
        StudentsBLL student = new StudentsBLL();//学生业务对象
        StudentsModel stumodel = new StudentsModel();
        public AddStudentsForm()
        {
            InitializeComponent();
        }

        private void AddStudentsForm_Load(object sender, EventArgs e)
        {
            BindCollege();
            
        }
        #region 绑定下拉列表
        /// <summary>
        /// 绑定学院下拉列表
        /// </summary>
        void BindCollege()
        {
            this.cmbCollege.DisplayMember = "学院名称";
            this.cmbCollege.ValueMember = "学院编号";
            this.cmbCollege.DataSource = college.GetAllColleges();
        }
        /// <summary>
        /// 绑定专业下拉列表
        /// </summary>
        void BindSpeciality()
        {
            specmodel.Speciality_ID = "%" + this.cmbCollege.SelectedValue.ToString()+"%";
            this.cmbSpeciality.DisplayMember = "专业名称";
            this.cmbSpeciality.ValueMember = "专业编号";
            this.cmbSpeciality.DataSource = spec.GetIdSpeciality(specmodel);
        }
        /// <summary>
        /// 绑定班级下拉列表
        /// </summary>
        void BindClasses()
        {
            //为班级实体对象班级所属专业赋值
            classmodel.Classes_Speciality = this.cmbSpeciality.SelectedValue.ToString();
            this.cmbClass.DisplayMember = "Classes_Name";
            this.cmbClass.ValueMember = "Classes_ID";
            this.cmbClass.DataSource = classes.GetClassesBySpeciality(classmodel);
        }

        private void cmbCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSpeciality();//绑定专业
            if (this.cmbSpeciality.Items.Count == 0)
            {
                this.labSpeYear.Text = "无";
                this.cmbClass.DataSource = null;
            }
            
        }

        private void cmbSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            //specmodel.Speciality_ID =this.cmbSpeciality.SelectedValue.ToString();
            ////MessageBox.Show(this.cmbSpeciality.SelectedValue.ToString());
            //string ss=speyear.GetSpeyearbySpeciality(specmodel).Rows[0].ToString();
            
            //this.labSpeYear.Text = ss;
            //BindClasses();

            specmodel.Speciality_ID = this.cmbSpeciality.SelectedValue.ToString();
            this.labSpeYear.Text= speyear.GetSpeyearbySpeciality(specmodel).Rows[0]["SpeYears_Name"].ToString();
            BindClasses();
            
        }
        #endregion

        #region 添加学生
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (this.cmbClass.SelectedValue == null)
            {
                MessageBox.Show("请先添加班级");
                return;
            }
            string name = this.txtName.Text.Trim();
            string sex = "男";
            if (this.radioButton2.Checked)
                sex = "女";
            string classes = this.cmbClass.SelectedValue.ToString();
            string card = this.txtCard.Text.Trim();//身份证号
            DateTime birth = this.dtpBirth.Value;//生日
            string origin = this.txtOrigin.Text.Trim();//籍贯
            string num = this.txtNum.Text.Trim();//入学后四位
            
            DateTime enter = this.dtpEnterYear.Value;//入学日期
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("学生姓名不能为空");
                return;
            }
            if (string.IsNullOrEmpty(num))
            {
                MessageBox.Show("请输入后四位学号");
                return;
            }
            string address = this.txtHome.Text.Trim();
            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("请填写联系方式");
                return;
            }
            string hometel = this.txtHomeTel.Text.Trim();
            if (string.IsNullOrEmpty(hometel))
            {
                MessageBox.Show("请填写联系方式");
                return;
            }
            string dormtel = this.txtDormTel.Text.Trim();
            string mobile = this.txtMobile.Text.Trim();
            string email=this.txtEmail.Text.Trim();
            
           
            if (string.IsNullOrEmpty(num))
            {
                MessageBox.Show("学号不能为空");
                return;
            }
            num = this.cmbClass.SelectedValue.ToString() + num;
            stumodel.Student_Name = name;
            stumodel.Student_Sex = sex;
            stumodel.StudentClass = classes;
            stumodel.StudentNum = num;
            stumodel.StudentEnterYear = enter;
            stumodel.StudentOrigin = origin;
            stumodel.StudentBirthDay = birth;
            stumodel.StudentCard = card;
            stumodel.StudentAddress = address;
            stumodel.FamilyTel = hometel;
            stumodel.DormTel = dormtel;
            stumodel.Mobile = mobile;
            stumodel.Email = email;

            bool b = student.CheckStudent(stumodel);
            if (b == true)
            {
                MessageBox.Show("该学生编号已存在");
                return;
            }
            student.AddStudents(stumodel);
               
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

    }
}

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
    public partial class AddScoreForm : Form
    {
        #region 绑定逻辑业务层
        CollegesBLL college = new CollegesBLL();//学院对象

        SpeYearsBLL speyear = new SpeYearsBLL();//学制业务对象
        SpeYearsModel spemodel = new SpeYearsModel();
        SpecialityBLL spec = new SpecialityBLL();//专业业务对象
        SpecialityModel specmodel = new SpecialityModel();
        ClassesBLL classes = new ClassesBLL();//班级业务对象
        ClassesModel classmodel = new ClassesModel();
        StudentsBLL student = new StudentsBLL();//学生业务对象
        StudentsModel stumodel = new StudentsModel();
        SubjectsBLL subject = new SubjectsBLL();//学科业务对象
        SubjectsModel submodel = new SubjectsModel();
        ExaminationBLL examin = new ExaminationBLL();//成绩业务对象
        ExaminationModel exammodel = new ExaminationModel();
        #endregion
        public AddScoreForm()
        {
            InitializeComponent();
        }

        private void AddScoreForm_Load(object sender, EventArgs e)
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
            specmodel.Speciality_ID = "%" + this.cmbCollege.SelectedValue.ToString() + "%";
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
        /// <summary>
        /// 绑定学生下拉列表
        /// </summary>
        void BindStudents()
        {
            stumodel.StudentClass = this.cmbClass.SelectedValue.ToString();
            this.cmbName.DisplayMember = "Student_Name";
            this.cmbName.ValueMember = "Student_ID";
            this.cmbName.DataSource = student.GetStudentByClasses(stumodel);
        }
        
        /// <summary>
        /// 绑定用户控件
        /// </summary>
        void Bindcontrl()
        {
            if (this.cmbSpeciality.SelectedValue != null)//如果有选中的专业
            {
                this.groupBox1.Controls.Clear();//清空上一个专业的学科
                //专业实体对象的专业编号属性为专业下拉列表选中的实际值
                specmodel.Speciality_ID = this.cmbSpeciality.SelectedValue.ToString();
                DataTable dt = subject.GetSubjectsBySpeciality(specmodel);
                int count = dt.Rows.Count;//查询结果集的行数
                if (count > 0)//如果有记录，则该专业下有学科
                {
                    for (int i = 0; i < count; i++)
                    {
                        UserControl1 user = new UserControl1();
                        user.labSubjectName.Text = dt.Rows[i]["Subjects_Name"].ToString();
                        user.labSubjectName.Tag = dt.Rows[i]["Subjects_ID"].ToString();
                        user.Location = new Point(10, 15 + 42 * i);//为用户控件定位
                        this.groupBox1.Controls.Add(user);//将用户控件添加到groupBox1
                    }
                }
            }
        }
        /// <summary>
        /// 获取选中学生的所有科目成绩
        /// </summary>
        void BindGrade()
        {
            exammodel.StudentID =Convert.ToInt32( this.cmbName.SelectedValue);
            //获取选中学生的所有科目成绩
            DataTable dt = examin.GetGreadByStudent(exammodel);
            int count = dt.Rows.Count;
            if (count > 0)
            { 
             for (int i = 0; i < count; i++)
             {
                UserControl1 user = (UserControl1)this.groupBox1.Controls[i];
                user.txtExamination.Text=dt.Rows[i]["ExamScore"].ToString();
                 user.txtExamination.Enabled=false;//禁用成绩文本框
             }
                this.btnAddChengj.Enabled=false;//禁用提交成绩按钮
                this.btnUpdateCj.Enabled=true;//启用修改按钮
            }
            else
            {
                for(int i=0;i<this.groupBox1.Controls.Count;i++)
                {
                UserControl1 user = (UserControl1)this.groupBox1.Controls[i];
                    user.txtExamination.Text="";
                    user.txtExamination.Enabled=true;//启用成绩文本框
                }
                this.btnAddChengj.Enabled=true;
                this.btnUpdateCj.Enabled=false;
            }
        
        }
        /// <summary>
        /// 选中学院下的专业
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                BindSpeciality();
            
            if (this.cmbSpeciality.Items.Count == 0)//如果专业列表中没有项
            {
                this.cmbClass.DataSource = null;//班级下拉列表数据源为空
                this.cmbName.DataSource = null;//学生下拉列表数据源为空
                this.labStuID.Text = "无学生";//学号无 
            }
        }
        /// <summary>
        /// 选中班级下的学生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindStudents();
        }
        /// <summary>
        /// 选中专业下的班级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClass.Items.Count == 0)
            {
                this.cmbClass.DataSource = null;
            }
            BindClasses(); 
        }
        /// <summary>
        /// 显示学生编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (this.cmbName.SelectedValue != null)
            {
                labStuID.Text = cmbName.SelectedValue.ToString();
            }
            else
            {
                labStuID.Text = "0";
            }
            Bindcontrl();
            BindGrade();
            
        }
        #endregion

        #region 添加学生成绩
        /// <summary>
        /// 添加学生学科成绩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCchengj_Click(object sender, EventArgs e)
        {
            //int count = groupBox1.Controls.Count;
            //string score = "";
            //for (int i = 0; i < count; i++)
            //{
            //    UserControl1 user = (UserControl1)groupBox1.Controls[i];
            //    if (user.txtExamination.Text.Trim() == "")
            //    { 
            //    score="0";
            //    }
            //    else
            //    {
            //        score = user.txtExamination.Text.Trim();
            //    }
                
            //    exammodel.StudentID = Convert.ToInt32(this.cmbName.SelectedValue);
            //    exammodel.SubjectsID =Convert.ToInt32( user.labSubjectName.Tag);
            //    exammodel.ExamScore =Convert.ToInt32( user.txtExamination.Text);
            //    examin.AddExamination(exammodel);
            int k=this.groupBox1.Controls.Count;
            List<ExaminationModel> list = new List<ExaminationModel>(k);
            for (int i = 0; i < k; i++)
            {
                ExaminationModel exa = new ExaminationModel();
                UserControl1 user = (UserControl1)groupBox1.Controls[i];
                exa.SubjectsID = Convert.ToInt32(user.labSubjectName.Tag);
                exa.ExamScore = int.Parse(user.txtExamination.Text.Trim());
                exa.StudentID = int.Parse(this.labStuID.Text);
                list.Add(exa);
            }
            int count = examin.AddExamination(k, list);
            if (count == k)
            {
                BindGrade();
                MessageBox.Show("成绩添加成功");
            }
            else
            {
                MessageBox.Show("成绩添加失败");
            }
        }
        #endregion
        /// <summary>
        /// 修改成绩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateCj_Click(object sender, EventArgs e)
        {
            int k = this.groupBox1.Controls.Count;
            List<ExaminationModel> list = new List<ExaminationModel>(k);
            for (int i = 0; i < k; i++)
            {
                ExaminationModel exa = new ExaminationModel();
                UserControl1 user = (UserControl1)groupBox1.Controls[i];
                exa.SubjectsID = Convert.ToInt32(user.labSubjectName.Tag);
                exa.ExamScore = int.Parse(user.txtExamination.Text.Trim());
                exa.StudentID = int.Parse(this.labStuID.Text);
                list.Add(exa);
            }
            int count = examin.UpdateExamination(k, list);
            if (count == k)
            {
                MessageBox.Show("成绩修改成功");
                BindGrade();
            }
            else
            {
                MessageBox.Show("成绩修改失败");
            }
        }
    }
}

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
    public partial class ClassManageForm : Form
    {
        
        ClassesBLL classes = new ClassesBLL();//班级业务对象 
        public ClassManageForm()
        {
            InitializeComponent();
        }

        private void ClassManageForm_Load(object sender, EventArgs e)
        {
           
        }
        #region  查询条件
        private void btnSelect_Click(object sender, EventArgs e)
        {
            
            
            string College = this.txtCollege.Text.Trim();
            string Speciality = this.txtSpeciality.Text.Trim();
            string Class = this.txtClasses.Text.Trim();
            string Teachers = this.txtTeacher.Text.Trim();
            if (string.IsNullOrEmpty(College)&&string.IsNullOrEmpty(Speciality)&&string.IsNullOrEmpty(Class)&&string.IsNullOrEmpty(Teachers))
            {
                MessageBox.Show("请输入查询条件");
                return;
            }
             DataTable dt = new DataTable();

            if (string.IsNullOrEmpty(Teachers))
            {
                if (string.IsNullOrEmpty(Class)==false)//
                {
                    ClassesModel clmodel = new ClassesModel();
                    clmodel.Classes_Name =Class;
                    dt= classes.GetClassesByClassName(clmodel);
                }
                else if (string.IsNullOrEmpty(Class)&& string.IsNullOrEmpty(Speciality) == false)
                {
                    SpecialityModel specmodel = new SpecialityModel();
                    specmodel.Speciality_Name = Speciality;
                    dt = classes.GetClassesBySpecialityName(specmodel);
                }
                else
                {
                    CollegesModel collmodel = new CollegesModel();
                    collmodel.College_Name = College;
                    dt = classes.GetClassesByCollegeName(collmodel);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Teachers) == false && string.IsNullOrEmpty(College) && string.IsNullOrEmpty(Speciality) && string.IsNullOrEmpty(Class))
                {
                    TeachersModel teamodel = new TeachersModel();
                    teamodel.Teacher_Name = Teachers;
                    dt = classes.GetClassesByTeacherName(teamodel);
                }
                else if (string.IsNullOrEmpty(Teachers) == false&&string.IsNullOrEmpty(Class) == false)
                {
                    ClassesModel clmodel = new ClassesModel();
                    clmodel.Classes_Name =Class;
                    TeachersModel teamodel = new TeachersModel();
                    teamodel.Teacher_Name = Teachers;
                    dt = classes.GetClassesByClassAndTeacher(clmodel, teamodel);
                }
                else if (string.IsNullOrEmpty(Teachers) == false && string.IsNullOrEmpty(Class) && string.IsNullOrEmpty(Speciality) == false)
                {
                    TeachersModel teamodel = new TeachersModel();
                    SpecialityModel specmodel = new SpecialityModel();
                    specmodel.Speciality_Name = Speciality;
                    teamodel.Teacher_Name = Teachers;

                    dt = classes.GetClassesBySpecialityAndTeacher(specmodel, teamodel);
                }
                else
                {
                    CollegesModel collmodel = new CollegesModel();
                    collmodel.College_Name = College;
                    TeachersModel teamodel = new TeachersModel();
                    teamodel.Teacher_Name = Teachers;
                    dt = classes.GetClassesByCollegeAndTeacher(collmodel, teamodel);

                }
 
            }
            this.dataGridView1.DataSource = dt;
        }
         #endregion

        
    }
}

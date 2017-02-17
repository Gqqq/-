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
    public partial class PropertyForm : Form
    {
        int sid;
        StudentsBLL student = new StudentsBLL();
        StudentsModel stumodel = new StudentsModel();
        public PropertyForm(int stuid)
        {
            this.sid = stuid;
            InitializeComponent();
        }

        private void PropertyForm_Load(object sender, EventArgs e)
        {
            BindStudent();
            BindChangeType();
            BindJiangType();
            BindFaType();
        }
        void BindStudent()
        {
            stumodel.Student_ID = sid;
            DataRow row=student.GetStudentsByID(stumodel).Rows[0];

            this.labAddress.Text = row["StudentAddress"].ToString();
            this.labBirth.Text = row["StudentBirthDay"].ToString();
            this.labCard.Text = row["StudentCard"].ToString();
            this.labClass.Text=row["Classes_Name"].ToString();
            this.labCollege.Text = row["College_Name"].ToString();
            this.labEnterYear.Text = row["StudentEnterYear"].ToString();
            this.labHomeTel.Text = row["FamilyTel"].ToString();
            this.labEmail.Text = row["Email"].ToString();
            this.labMobile.Text = row["Mobile"].ToString();
            this.labDormTel.Text = row["DormTel"].ToString();
            this.labNum.Text = row["StudentNum"].ToString();
            this.labSpec.Text = row["Speciality_Name"].ToString();
            this.labName.Text = row["Student_Name"].ToString();
            this.labSex.Text = row["Student_Sex"].ToString();
            this.labOrigin.Text = row["StudentOrigin"].ToString();
            this.labSpeYear.Text = row["SpeYears_Name"].ToString();
        }
        void BindChangeType()
        {
            
            ChangeRecodeBLL recode = new ChangeRecodeBLL();
            ChangeTypesRecodeModel model = new ChangeTypesRecodeModel();
            model.ChangeStudentID = sid;
            this.dgvXueJiType.DataSource = recode.GetAllChangeTypeRecode(model);
        }
        void BindJiangType()
        {
            JiangFaRecodeBLL jiangfa = new JiangFaRecodeBLL();
            JiangFaModel jiangfamodel = new JiangFaModel();
            jiangfamodel.PunishmentAwardsStudentID = sid;
            this.dgvJiang.DataSource = jiangfa.GetJiangRecodeByStudent(jiangfamodel);
        }
        void BindFaType()
        {
            JiangFaRecodeBLL jiangfa = new JiangFaRecodeBLL();
            JiangFaModel jiangfamodel = new JiangFaModel();
            jiangfamodel.PunishmentAwardsStudentID = sid;
            this.dgvFa.DataSource = jiangfa.GetFaRecodeByStudent(jiangfamodel);
        }


    }
}

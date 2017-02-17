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
    public partial class EditForm : Form
    {
        int sid;
        
        ChangeTypesBLL change = new ChangeTypesBLL();

        ChangeRecodeBLL changerecode = new ChangeRecodeBLL();
        ChangeTypesRecodeModel changemodel = new ChangeTypesRecodeModel();

        JiangFaTypesBLL jiangfatype = new JiangFaTypesBLL();
        JiangFaTypesModel jiangfatypemodel = new JiangFaTypesModel();

        JiangFaRecodeBLL jiangfa = new JiangFaRecodeBLL();
        JiangFaModel jiangfamodel = new JiangFaModel();

        CollegesBLL college = new CollegesBLL();//学院对象

        SpeYearsBLL speyear = new SpeYearsBLL();//学制业务对象
        SpeYearsModel spemodel = new SpeYearsModel();
        SpecialityBLL spec = new SpecialityBLL();//专业业务对象
        SpecialityModel specmodel = new SpecialityModel();
        ClassesBLL classes = new ClassesBLL();//班级业务对象
        ClassesModel classmodel = new ClassesModel();
        StudentsBLL student = new StudentsBLL();//学生业务对象
        StudentsModel stumodel = new StudentsModel();
        public EditForm(int stuid)
        {
            
            this.sid = stuid;
            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            BindCollege();//绑定学院
            BindStudent();//绑定学生信息
            BindChangeType();//绑定学籍异动类型
            BindJiangType();//绑定奖励类型
            BindFaType();//绑定处罚类型
            GetAllChangeType();//绑定学籍异动信息
            GetAllJiangType();//绑定奖励信息
            GetAllFaType();//绑定处罚信息
        }
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
        /// 绑定学生信息
        /// </summary>
        void BindStudent()
        {
            stumodel.Student_ID = sid;
            DataRow row = student.GetStudentsByID(stumodel).Rows[0];

            this.txtHome.Text = row["StudentAddress"].ToString();
            this.dtpBirth.Value =Convert.ToDateTime (row["StudentBirthDay"]);
            this.txtCard.Text = row["StudentCard"].ToString();
            this.cmbClass.Text = row["Classes_Name"].ToString();
            this.cmbCollege.Text = row["College_Name"].ToString();
            this.dtpEnterYear.Value =Convert.ToDateTime (row["StudentEnterYear"]);
            this.txtHomeTel.Text = row["FamilyTel"].ToString();
            this.txtEmail.Text = row["Email"].ToString();
            this.txtMobile.Text = row["Mobile"].ToString();
            this.txtDormTel.Text = row["DormTel"].ToString();
            this.txtNum.Text = row["StudentNum"].ToString().Substring(8, 4);
            this.cmbSpeciality.Text = row["Speciality_Name"].ToString();
            this.txtName.Text = row["Student_Name"].ToString();
            if (row["Student_Sex"].ToString() == "男")
                this.radioButton1.Checked = true;
            else
                this.radioButton2.Checked = true;
            this.txtOrigin.Text = row["StudentOrigin"].ToString();
            this.labSpeYear.Text = row["SpeYears_Name"].ToString();
        }

        void BindChangeType()
        {
            this.cmbChangetype.DisplayMember = "异动类型名称";
            this.cmbChangetype.ValueMember = "异动类型编号";
            this.cmbChangetype.DataSource=change.GetAllChangeTypes();
        }
        void BindJiangType()
        {
            this.cmbJiangType.DisplayMember = "PunishmentAwardTypes_Name";
            this.cmbJiangType.ValueMember = "PunishmentAwardTypes_ID";
            this.cmbJiangType.DataSource = jiangfatype.GetJiangTypes(jiangfatypemodel);
        }
        void BindFaType()
        {
            this.cmbFaType.DisplayMember = "PunishmentAwardTypes_Name";
            this.cmbFaType.ValueMember = "PunishmentAwardTypes_ID";
            this.cmbFaType.DataSource = jiangfatype.GetFaTypes(jiangfatypemodel);
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
            specmodel.Speciality_ID = this.cmbSpeciality.SelectedValue.ToString();
            this.labSpeYear.Text = speyear.GetSpeyearbySpeciality(specmodel).Rows[0]["SpeYears_Name"].ToString();
            BindClasses();
        }
        /// <summary>
        /// 编辑学生信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
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

            string address = this.txtHome.Text.Trim();
            string hometel = this.txtHomeTel.Text.Trim();
            string dormtel = this.txtDormTel.Text.Trim();
            string mobile = this.txtMobile.Text.Trim();
            string email = this.txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("学生姓名不能为空");
                return;
            }

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
            stumodel.Student_ID = sid;
            student.UpdateStudent(stumodel);
        }
        #region 添加学籍异动信息
        /// <summary>
        /// 添加学籍异动信息
        /// </summary>
        void GetAllChangeType()
        {
            changemodel.ChangeStudentID = sid;
            this.dgvChangeType.DataSource = changerecode.GetAllChangeTypeRecode(changemodel);
        }
        private void btnAddChangeType_Click(object sender, EventArgs e)
        {
            
            int types = Convert.ToInt32( this.cmbChangetype.SelectedValue);
            DateTime time = this.dtpChangetype.Value;
            string reason = this.txtChangeReason.Text;

            changemodel.ChangeTypes_ID = types;
            changemodel.ChangeDate = time;
            changemodel.ChangeReason = reason;
            changemodel.ChangeStudentID = sid;

            changerecode.AddChangeRecode(changemodel);
            GetAllChangeType();
        }
        #endregion

        #region 添加奖励信息
        /// <summary>
        /// 添加奖励信息
        /// </summary>
        void GetAllJiangType()
        {
            jiangfamodel.PunishmentAwardsStudentID = sid;
            this.dgvJiangType.DataSource = jiangfa.GetJiangRecodeByStudent(jiangfamodel);
        }
        private void btnAddJiang_Click(object sender, EventArgs e)
        {
            int types =Convert.ToInt32( this.cmbJiangType.SelectedValue);
            DateTime time = this.dtpJiangReason.Value;
            string reason = this.txtJiangReason.Text;
            string content = this.txtJiangContent.Text;

            jiangfamodel.PunishmentAwardsType_ID = types;
            jiangfamodel.PunishmentAwardsDate = time;
            jiangfamodel.PunishmentAwardsReason = reason;
            jiangfamodel.PunishmentAwardsContent = content;
            jiangfamodel.PunishmentAwardsStudentID = sid;

            jiangfa.AddJingFa(jiangfamodel);
            GetAllJiangType();
        }
        #endregion

        #region 添加处罚信息
        /// <summary>
        /// 添加处罚信息
        /// </summary>
        void GetAllFaType()
        {
            jiangfamodel.PunishmentAwardsStudentID = sid;
            this.dgvFaType.DataSource = jiangfa.GetFaRecodeByStudent(jiangfamodel);
        }
        private void btnAddFa_Click(object sender, EventArgs e)
        {
            int types = Convert.ToInt32(this.cmbFaType.SelectedValue);
            DateTime time = this.dtpFaReason.Value;
            string reason = this.txtFaContent.Text;
            string content = this.txtFaContent.Text;

            jiangfamodel.PunishmentAwardsType_ID = types;
            jiangfamodel.PunishmentAwardsDate = time;
            jiangfamodel.PunishmentAwardsReason = reason;
            jiangfamodel.PunishmentAwardsContent = content;
            jiangfamodel.PunishmentAwardsStudentID = sid;

            jiangfa.AddJingFa(jiangfamodel);
            GetAllFaType();
        }
        #endregion

        private void btnDelChangetype_Click(object sender, EventArgs e)
        {
            changemodel.ChangeTypesRecode_ID =Convert.ToInt32( this.dgvChangeType.SelectedRows[0].Cells["异动编号"].Value.ToString());
            changerecode.DelAllChangeRecode(changemodel);
            GetAllChangeType();
            
        }

        private void btnDelJiang_Click(object sender, EventArgs e)
        {
            jiangfamodel.PunishmentAwardsRecode_ID = Convert.ToInt32( this.dgvJiangType.SelectedRows[0].Cells["奖励编号"].Value.ToString());
            jiangfa.DelJiangFa(jiangfamodel);
            GetAllJiangType();
        }

        private void btnDelFa_Click(object sender, EventArgs e)
        {
            jiangfamodel.PunishmentAwardsRecode_ID = Convert.ToInt32(this.dgvFaType.SelectedRows[0].Cells["处罚编号"].Value.ToString());
            jiangfa.DelJiangFa(jiangfamodel);
            GetAllFaType();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}

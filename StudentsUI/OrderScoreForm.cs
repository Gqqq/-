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
    public partial class OrderScoreForm : Form
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
        SubjectsBLL subject = new SubjectsBLL();//学科业务对象
        SubjectsModel submodel = new SubjectsModel();
        ExaminationBLL examin = new ExaminationBLL();//成绩业务对象
        ExaminationModel exammodel = new ExaminationModel();
        public OrderScoreForm()
        {
            InitializeComponent();
        }

        private void OrderScoreForm_Load(object sender, EventArgs e)
        {
            BindCollege();
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
        /// 绑定用户控件
        /// </summary>
        void BindSubject()
        {
            specmodel.Speciality_ID= this.cmbSpeciality.SelectedValue.ToString();
            this.cmbSubjects.DisplayMember = "Subjects_Name";
            this.cmbSubjects.ValueMember = "Subjects_ID";
            this.cmbSubjects.DataSource = subject.GetSubjectsBySpeciality(specmodel);
        }
        private void cmbCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSpeciality();

            if (this.cmbSpeciality.Items.Count == 0)//如果专业列表中没有项
            {
                this.cmbClass.DataSource = null;//班级下拉列表数据源为空
                this.cmbSubjects.DataSource = null;//学生下拉列表数据源为空
                
            }
        }
        private void cmbSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClass.Items.Count == 0)
            {
                this.cmbClass.DataSource = null;
            }
            BindClasses();
            BindSubject();
        }

        private void cmbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 按班级单科排名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClassOne_Click(object sender, EventArgs e)
        {
            if (this.cmbSubjects.SelectedValue == null || this.cmbClass.SelectedValue == null)
            {
                MessageBox.Show("你还没选中班级或学科");
                return;
            }
            else
            {
                bool bo = false;
                if (this.checkBox1.Checked)
                    bo = true;
                else
                    bo = false;
                classmodel.Classes_ID = this.cmbClass.SelectedValue.ToString();
                submodel.Subjects_ID =Convert.ToInt32( this.cmbSubjects.SelectedValue);
                this.dataGridView1.DataSource = examin.OrderBySingleClass(bo,classmodel, submodel);
            }
        }
        /// <summary>
        /// 按专业单科排名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpecialityOne_Click(object sender, EventArgs e)
        {
            if (this.cmbSubjects.SelectedValue == null || this.cmbSpeciality.SelectedValue == null)
            {
                MessageBox.Show("你还没选中专业或学科");
                return;
            }
            else
            {
                bool bo = false;
                if (this.checkBox1.Checked)
                    bo = true;
                else
                    bo = false;
                specmodel.Speciality_ID = this.cmbSpeciality.SelectedValue.ToString();
                submodel.Subjects_ID = Convert.ToInt32(this.cmbSubjects.SelectedValue);
                this.dataGridView1.DataSource = examin.OrderBySingleSpeciality(bo,specmodel, submodel);
            }
        }
        /// <summary>
        /// 按班级总成绩排名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            if (this.cmbClass.SelectedValue == null || this.cmbSubjects.SelectedValue == null)
            {
                MessageBox.Show("你还没选中专业或学科");
                return;
            }
            //创建某班级成绩表作为DataRowView的数据源
            DataTable dt = new DataTable();
            //为dt表创建数据列
            DataColumn cnum = new DataColumn("学号", typeof(string));//第一列显示学生学号
            DataColumn cname = new DataColumn("姓名", typeof(string));//第二列显示学生姓名
            dt.Columns.Add(cnum);
            dt.Columns.Add(cname);//将此列添加到dt表中
            //遍历学科下拉列表，将每个学科构造成表中的列，列名为学科名称
            for (int i = 0; i < cmbSubjects.Items.Count; i++)
            {
                string subname = ((DataRowView)this.cmbSubjects.Items[i])["Subjects_Name"].ToString();
                DataColumn cgrade = new DataColumn(subname, typeof(int));
                cgrade.DefaultValue = 0;//默认值为0
                dt.Columns.Add(cgrade);
            }
            DataColumn csum = new DataColumn("总分", typeof(int));
            dt.Columns.Add(csum);
            //为dt表添加数据行
            //2.1根据班级编号在学生表中选出该班级所有学生信息形成数据表stu
            StudentsModel stumodel = new StudentsModel();
            stumodel.StudentClass = this.cmbClass.SelectedValue.ToString();
            DataTable stu = student.GetStudentByClasses(stumodel);//查询选中班的所有学生，形成学生表
            //2.2根据班级编号在成绩表中选出改版机所有学生所有科目的成绩形成数据表exam
            ClassesModel classmodel = new ClassesModel();
            classmodel.Classes_ID = this.cmbClass.SelectedValue.ToString();
            DataTable exam = examin.GetAllGradeByClass(classmodel);
                //遍历学生表中所有行，将每个学生构造成一个和自定义的dt表具有相同结构的数据行
            for (int i = 0; i < stu.Rows.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["学号"] = stu.Rows[i]["StudentNum"];//初始化一个和dt表具有相同结构的数据行
                row["姓名"] = stu.Rows[i]["Student_Name"];//从学生表第i行取出学号列，赋给dt表学号

                //从结果集成绩表中再次查询第i个学生的所有成绩，返回数据行集合
                DataRow[] rows = exam.Select("StudentID=" + stu.Rows[i]["Student_ID"]);
                int total = 0;//总分
                string name;//科目的列名
                int score = 0;
                for (int j = 0; j < rows.Length; j++)
                {
                    //获取科目名称
                    name = ((DataRowView)this.cmbSubjects.Items[j])["Subjects_Name"].ToString();
                    score =Convert.ToInt32( rows[j]["ExamScore"]);//把第i个学生的第j个成绩取出
                    row[name] = score;//把成绩填充到第i行中的某科目中
                    total += score;//累加总分
                }
                    row["总分"] = total;
                    dt.Rows.Add(row);//将构造好的行添加到行集合
            }
            //3,创建数据表dt的视图view进行排序
            DataView view = dt.DefaultView;
            if (this.checkBox1.Checked)//若按总分高低排序被勾选
            {
                view.Sort = "总分 desc";//则按总分列降序排列
            }
            else
            {
                view.Sort = "总分 asc";
            }
                this.dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            if (this.cmbClass.SelectedValue == null || this.cmbSubjects.SelectedValue == null)
            {
                MessageBox.Show("你还没选中专业或学科?");
                return;
            }
            //创建某专业表dt作为datagridview的数据源
            DataTable dt = new DataTable();
            //为dt表创建数据列
            DataColumn cnum = new DataColumn("学号", typeof(string));//创建学号列
            DataColumn cname = new DataColumn("姓名", typeof(string));//创建姓名列
            dt.Columns.Add(cnum);
            dt.Columns.Add(cname);//将此列添加到表dt中
            //遍历学科列表，将每个学科构建成表中的列，列名为学科名称
            for (int i = 0; i < cmbSubjects.Items.Count; i++)
            {
                string subname = ((DataRowView)this.cmbSubjects.Items[i])["Subjects_Name"].ToString();
                DataColumn cgrade = new DataColumn(subname, typeof(int));
                cgrade.DefaultValue = 0;//默认值为0
                dt.Columns.Add(cgrade);
            }
            DataColumn csum = new DataColumn("总分", typeof(int));
            dt.Columns.Add(csum);
            //为dt表添加数据行
            //2.1根据专业编号选出该专业所有学生所有信息的成绩形成信息表
            ClassesModel clamodel = new ClassesModel();
            StudentsBLL student = new StudentsBLL();
            clamodel.Classes_Speciality = this.cmbSpeciality.SelectedValue.ToString();
            DataTable stu = student.GetStudentsBySpec(clamodel);//查询选中专业的所有学生形成学生表
            //2.2根据专业编号选出该班级所有学生所有科目的成绩形成成绩表
            SpecialityModel spemodel = new SpecialityModel();
            spemodel.Speciality_ID = this.cmbSpeciality.SelectedValue.ToString();
            DataTable exam = examin.GetAllGradeBySpeciality(spemodel);
            //遍历学生表中所有行,将每个学生构造成一个和自定义的ì?dt表具有相同结构的数据行
            for (int i = 0; i < stu.Rows.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["学号"] = stu.Rows[i]["StudentNum"];//初始化一个表具有相同结构的数据行
                row["姓名"] = stu.Rows[i]["Student_Name"];//从学生表第i行取出学号列赋dt表学号?

                //从结果集表中再次查询单个成绩并返回数据行集合    
                DataRow[] rows = exam.Select("StudentID=" + stu.Rows[i]["Student_ID"]);
                int total = 0;//总分
                string name;//科目的列名
                int score = 0;
                for (int j = 0; j < rows.Length; j++)
                {
                    //获取科目名称
                    name = ((DataRowView)this.cmbSubjects.Items[j])["Subjects_Name"].ToString();
                    score = Convert.ToInt32(rows[j]["ExamScore"]);//把第i个学生的第i个成绩取出
                    row[name] = score;//填充成绩到表中
                    total += score;//累加总分
                }
                row["总分"] = total;
                dt.Rows.Add(row);//将构造好的行添加到行集合
            }
            //3创建数据表的视图进行排序
            DataView view = dt.DefaultView;
            if (this.checkBox1.Checked)
            {
                view.Sort = "总分 desc";
            }
            else
            {
                view.Sort = "总分 asc";
            }
            this.dataGridView1.DataSource = dt;
        }
    }
}

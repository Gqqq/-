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
using System.Data.SqlClient;

namespace StudentsUI
{
    public partial class MainForm : Form
    {
        public int adminid;
        public string level;
        public MainForm()
        {
            InitializeComponent();
        }
        CollegesBLL college = new CollegesBLL();
        CollegesModel collmodel = new CollegesModel();
        SpecialityBLL speciality = new SpecialityBLL();
        SpecialityModel specmodel = new SpecialityModel();
        ClassesBLL classes = new ClassesBLL();
        ClassesModel clamodel = new ClassesModel();
        StudentsBLL student = new StudentsBLL();
        StudentsModel stumodel = new StudentsModel();
        private void 类型参数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypeSetForms ts = new TypeSetForms();
            ts.Owner = this;
            ts.Show();
        }

        private void 组织机构设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrgSetForm of = new OrgSetForm();
            of.Owner = this;
            of.Show();
        }

        private void 新建XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentsForm asf = new AddStudentsForm();
            asf.Owner = this;
            asf.Show();
        }
        #region 绑定树节点
        /// <summary>
        /// 树视图一级节点：绑定显示所有专业
        /// </summary>
        void BindCollege()
        {
            this.tvwOrg.Nodes.Clear();
            DataTable dt = college.GetAllColleges();
            foreach (DataRow row in dt.Rows)
            {
                TreeNode coll = new TreeNode();
                coll.Text = row["学院名称"].ToString();
                coll.Tag = row["学院编号"];
                coll.ImageIndex = 0;
                this.tvwOrg.Nodes.Add(coll);
                BindSpeciality(coll);//在该学院下绑定专业
            }
        }
        /// <summary>
        /// 树视图二级节点：绑定指定学院下的专业
        /// </summary>
        /// <param name="t">上一级节点</param>
        void BindSpeciality(TreeNode t)
        {
            specmodel.Speciality_ID = "%" + t.Tag.ToString()+"%";
            DataTable dt = speciality.GetIdSpeciality(specmodel);
            foreach (DataRow r in dt.Rows)
            {
                TreeNode spec = new TreeNode();
                spec.Text = r["专业名称"].ToString();
                spec.Tag = r["专业编号"];
                spec.ImageIndex = 0;
                t.Nodes.Add(spec);
                BindClass(spec);//在该专业下绑定班级节点
            }
        }
        /// <summary>
        /// 树视图三级节点：绑定显示指定专业下的班级
        /// </summary>
        /// <param name="t"></param>
        void BindClass(TreeNode t)
        {
            clamodel.Classes_Speciality = t.Tag.ToString();
            DataTable dt = classes.GetClassesBySpeciality(clamodel);
            foreach (DataRow r in dt.Rows)
            {
                TreeNode clas = new TreeNode();
                clas.Text = r["Classes_Name"].ToString();
                clas.Tag = r["Classes_ID"];
                clas.ImageIndex = 0;
                t.Nodes.Add(clas);
            }
        }
        #endregion

        #region 刷新列表视图
        /// <summary>
        /// 刷新
        /// </summary>
        void BindListView()
        {
            
            this.lvwStudent.Items.Clear();//清空列表
            //获取选中节点的Tag值，即编号
            string id = this.tvwOrg.SelectedNode.Tag.ToString();
            stumodel.StudentClass = id;
            DataTable dt = student.GetStudentByClasses(stumodel);
            if (id.Length == 8)//编号长度为8位，则为班级编号，查询该班所有学生
            {
                stumodel.StudentClass = id;
                dt = student.GetStudentByClasses(stumodel);
            }
            if (id.Length == 4)
            {
                clamodel.Classes_Speciality = id;
                dt = student.GetStudentsBySpec(clamodel);
            }
            if (id.Length == 2)
            {
                specmodel.Speciality_College = id;
                dt = student.GetStudentsByCollege(specmodel);
            }
            foreach (DataRow r in dt.Rows)
            {
                ListViewItem lv = new ListViewItem();//实例化一个列表项
                lv.Text = r["Student_Name"].ToString();//项的文本
                lv.Tag = r["Student_ID"];//项的关联数据
                if (r["Student_Sex"].ToString() == "男")
                    lv.ImageIndex = 0;
                else
                    lv.ImageIndex = 1;
                //添加子项
                lv.SubItems.Add(r["StudentNum"].ToString());
                lv.SubItems.Add(r["Student_Sex"].ToString());
                lv.SubItems.Add(r["College_Name"].ToString());
                lv.SubItems.Add(r["Speciality_Name"].ToString());
                lv.SubItems.Add(r["StudentEnterYear"].ToString());
                lv.SubItems.Add(r["SpeYears_Name"].ToString());
                lv.SubItems.Add(r["StudentOrigin"].ToString());
                this.lvwStudent.Items.Add(lv);

            }
        }
        #endregion

        #region 窗体加载事件
        private void MainForm_Load(object sender, EventArgs e)
        {
            UserLoginForm lf = new UserLoginForm();
            lf.Owner = this;
            lf.ShowDialog();
            
            BindCollege();
            this.skinEngine1.SkinFile = "VS2008皮肤\\Page.ssk";
        }
        #endregion

        #region 选中树节点后ListView中显示选中班级的所有学生
        /// <summary>
        /// 选中树节点后ListView中显示选中班级的所有学生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwOrg_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)//如果选中列表为空返回
                return;
            //this.lvwStudent.Items.Clear();//清空列表
            ////获取选中节点的Tag值，即编号
            //string id = this.tvwOrg.SelectedNode.Tag.ToString();
            //stumodel.StudentClass = id;
            //DataTable dt = student.GetStudentByClasses(stumodel);
            ////if (id.Length == 8)//编号长度为8位，则为班级编号，查询该班所有学生
            ////{
            ////    stumodel.StudentClass = id;
            ////    dt = student.GetStudentByClasses(stumodel);
            ////}
            ////if (id.Length == 4)//编号长度为4为，则为专业编号，查询该专业下的所有学生
            ////{

            ////}

            //foreach (DataRow r in dt.Rows)
            //{
            //    ListViewItem lv = new ListViewItem();//实例化一个列表项
            //    lv.Text = r["Student_Name"].ToString();//项的文本
            //    lv.Tag = r["Student_ID"];//项的关联数据
            //    if (r["Student_Sex"].ToString() == "男")
            //        lv.ImageIndex = 0;
            //    else
            //        lv.ImageIndex = 1;
            //    //添加子项
            //    lv.SubItems.Add(r["StudentNum"].ToString());
            //    lv.SubItems.Add(r["Student_Sex"].ToString());
            //    lv.SubItems.Add(r["College_Name"].ToString());
            //    lv.SubItems.Add(r["Speciality_Name"].ToString());
            //    lv.SubItems.Add(r["StudentEnterYear"].ToString());
            //    lv.SubItems.Add(r["SpeYears_Name"].ToString());
            //    lv.SubItems.Add(r["StudentOrigin"].ToString());
            //    this.lvwStudent.Items.Add(lv);
            //    
            //} 
            BindListView();
        }
        #endregion

        #region 查看学生属性
        private void 属性PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = this.lvwStudent.SelectedItems.Count;//获取选中项数量
            if (count == 1)
            {
                //获取用户在列表视图中选择项的Tag值，即学生编号
                int stuid = Convert.ToInt32(this.lvwStudent.SelectedItems[0].Tag);
                //创建属性窗体对象时，用构造函数将学生编号传到属性窗体
                PropertyForm p = new PropertyForm(stuid);
                p.Owner = this;
                p.Show();
            }
            else if (count == 0)
            {
                MessageBox.Show("请选择一个学生查看属性");
                return;
            }
            else if (count > 1)
            {
                MessageBox.Show("不能查看多个学生属性，只能选一个");
                return;
            }
        }
        #endregion

        #region 对学生进行编辑
        private void 编辑EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count=this.lvwStudent.SelectedItems.Count;
            if (count > 1)
            {
                MessageBox.Show("一次只能选择一名学生编辑");
                return;
            }
            else if (count == 1)
            {
                int stuid = Convert.ToInt32(this.lvwStudent.SelectedItems[0].Tag);
                EditForm edit = new EditForm(stuid);
                edit.Owner = this;
                edit.Show();
            }
            else if (count==0)
            {
                MessageBox.Show("请选择一名学生");
                return;
            }
        }
        #endregion

        #region 删除学生
        private void 删除DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (this.lvwStudent.SelectedItems.Count > 0)
            //{
            //    int count = 0, ch = 0, er = 0;
            //    count = this.lvwStudent.SelectedItems.Count;//总行

            //    foreach (ListViewItem it in this.lvwStudent.SelectedItems)
            //    {
            //        stumodel.Student_ID = Convert.ToInt32(it.Tag);
            //        int i = student.DelStudents(stumodel);
            //        if (i > 0)
            //        {
            //            ch++;
            //        }
            //        else
            //        {
            //            er++;
            //        }
            //    }
            //    string s = string.Format("总共删除{0}行,成功{}行,失败{}行", count, ch, er);
            //    MessageBox.Show(s);
            //}
            //else
            //{
            //    MessageBox.Show("你还没选中要删除的项");
            //    return;
            //}
            stumodel.Student_ID =Convert.ToInt32( this.lvwStudent.SelectedItems[0].Tag);
            try
            {
                student.DelStudents(stumodel);
                BindListView();
            }
            catch
            {
                MessageBox.Show("请谨慎删除学生信息");
            }
            
        }
        #endregion

        #region 调用列表视图刷新
        private void toolStrip刷新_Click(object sender, EventArgs e)
        {
            BindListView();
            BindCollege();
        }
        #endregion
        private void 添加AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScoreForm asf = new AddScoreForm();
            asf.Owner = this;
            asf.Show();
        }

        private void 排名CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderScoreForm osf = new OrderScoreForm();
            osf.Owner = this;
            osf.Show();
        }
        #region 管理员权限
        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (level == "超级管理员")
            {
                UserManageForm umf = new UserManageForm();
                umf.Owner = this;
                umf.Show();
            }
            else
            {
                MessageBox.Show("您不是超级管理员,不能进行此项操作！");
            }
        }
        #endregion

        private void 更改个人密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm cpf = new ChangePasswordForm();
            cpf.Owner = this;
            cpf.Show();
        }
        #region 大小图标
        private void 大图标LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.lvwStudent.View = View.LargeIcon;
        }

        private void 小图标MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.lvwStudent.View = View.SmallIcon;
        }

        private void 关闭XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                                            
        private void 工具栏TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.工具栏TToolStripMenuItem.Checked)
            {
            this.工具栏TToolStripMenuItem.Checked = false;
            this.toolStrip1.Visible = false;
            }
            else
            {
                this.工具栏TToolStripMenuItem.Checked = true;
                this.toolStrip1.Visible = true;
            }
        }
       

        private void 状态栏SToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 列表LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.lvwStudent.View = View.List;
        }

        private void 详细信息DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.lvwStudent.View = View.Details;
        }

        private void 刷新RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindListView();
        }

        private void 班级管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassManageForm cmf = new ClassManageForm();
            cmf.Owner = this;
            cmf.Show();
        }

        private void 查看VToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 皮肤
        private void mSNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.skinEngine1.SkinFile = "VS2008皮肤\\MSN.ssk";
        }
       
        private void pageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.skinEngine1.SkinFile = "VS2008皮肤\\Page.ssk";
        }
        #endregion

        #region 工具栏菜单
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            stumodel.Student_ID = Convert.ToInt32(this.lvwStudent.SelectedItems[0].Tag);
            try
            {
                student.DelStudents(stumodel);
                BindListView();
            }
            catch
            {
                MessageBox.Show("请谨慎删除学生信息");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddStudentsForm asf = new AddStudentsForm();
            asf.Owner = this;
            asf.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int count = this.lvwStudent.SelectedItems.Count;//获取选中项数量
            if (count == 1)
            {
                //获取用户在列表视图中选择项的Tag值，即学生编号
                int stuid = Convert.ToInt32(this.lvwStudent.SelectedItems[0].Tag);
                //创建属性窗体对象时，用构造函数将学生编号传到属性窗体
                PropertyForm p = new PropertyForm(stuid);
                p.Owner = this;
                p.Show();
            }
            else if (count == 0)
            {
                MessageBox.Show("请选择一个学生查看属性");
                return;
            }
            else if (count > 1)
            {
                MessageBox.Show("不能查看多个学生属性，只能选一个");
                return;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            int count = this.lvwStudent.SelectedItems.Count;
            if (count > 1)
            {
                MessageBox.Show("一次只能选择一名学生编辑");
                return;
            }
            else if (count == 1)
            {
                int stuid = Convert.ToInt32(this.lvwStudent.SelectedItems[0].Tag);
                EditForm edit = new EditForm(stuid);
                edit.Owner = this;
                edit.Show();
            }
            else if (count == 0)
            {
                MessageBox.Show("请选择一名学生");
                return;
            }
        }
        #endregion

        
    }
}

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
    public partial class TypeSetForms : Form
    {
        //创建两个全局变量
        ChangeTypesModel model = new ChangeTypesModel();
        public TypeSetForms()
        {
            InitializeComponent();
        }

        #region 创建查询所有异动类型的方法
        /// <summary>
        /// 创建查询所有异动类型的方法
        /// </summary>
        void GetAllChangeTypes()
        {
            ChangeTypesBLL change = new ChangeTypesBLL();
            dataGridView1.DataSource = change.GetAllChangeTypes();
        }
        #endregion

        #region 创建查询所有奖罚类型的方法
        /// <summary>
        /// 创建查询所有奖罚类型的方法
        /// </summary>
        void GetAllJiangFaTypes()
        {
            JiangFaTypesBLL JiangFa = new JiangFaTypesBLL();
            dataGridView2.DataSource = JiangFa.GetAllJiangFaTypes();
        }
        #endregion

        #region 窗体加载时调用事件
        private void TypeSetForms_Load(object sender, EventArgs e)
        {
            GetAllChangeTypes();
            this.cboName.SelectedIndex = 0;
        }
        #endregion

        #region 添加数据异动类型
        private void btnAdd1_Click(object sender, EventArgs e)
        {
            ChangeTypesBLL change = new ChangeTypesBLL();
            if (string.IsNullOrEmpty(this.txtxuejiName.Text))
            {
                MessageBox.Show("数据异动类型不能为空");
                return;
            }
            model.ChangeTypes_Name = this.txtxuejiName.Text;
            change.AddChangeTypes(model);
            GetAllChangeTypes();
        }
        #endregion

        #region 删除数据异动类型
        private void btnDele1_Click(object sender, EventArgs e)
        {
            ChangeTypesBLL change = new ChangeTypesBLL();
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int ID = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["异动类型编号"].Value);
                model.ChangeTypes_ID = ID;
                change.DeleChangeTypes(model);
                GetAllChangeTypes();
            }
        }
        #endregion 

        #region 选项卡Selecting事件，根据索引改变dataGridView中所绑定的值
        private void tctlshezhi_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)//当选项卡索引为0时
            {
                GetAllChangeTypes();
            }
            else if (e.TabPageIndex == 1)
            {
                GetAllJiangFaTypes();
            }
        }
        #endregion

        #region 添加奖罚类型
        /// <summary>
        /// 添加奖罚类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            JiangFaTypesModel model = new JiangFaTypesModel();
            JiangFaTypesBLL JiangFa = new JiangFaTypesBLL();
            string name = this.cboName.SelectedItem.ToString();
            object max=JiangFa.GetMaxJiangFaTypes();
            object min = JiangFa.GetMinJiangFaTypes();
            int id=0 ;
            if (name == "奖励")
            {
                if (string.IsNullOrEmpty(max.ToString()))
                {
                    id = 1;
                }
                else if (Convert.ToInt32(max) < 0)
                {
                    id = 1;
                }
                else
                {
                    id = Convert.ToInt32(max) + 1;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(min.ToString()))
                {
                    id = -1;
                }
                else if (Convert.ToInt32(min) > 0)
                {
                    id = -1;
                }
                else
                {
                    id = Convert.ToInt32(min) - 1;
                }
            }
            model.PunishmentAwardTypes_ID = id;
            model.PunishmentAwardTypes_Name = this.txtName.Text;
            JiangFa.AddJiangFaTypes(model);
            GetAllJiangFaTypes();

        }
        #endregion

        #region 删除奖罚类型
        private void btnDele_Click(object sender, EventArgs e)
        {
            JiangFaTypesBLL JiangFa = new JiangFaTypesBLL();
            JiangFaTypesModel model = new JiangFaTypesModel();
            if (this.dataGridView2.SelectedRows.Count > 0)
            {
                int ID = Convert.ToInt32(this.dataGridView2.SelectedRows[0].Cells["奖罚类型编号"].Value);
                model.PunishmentAwardTypes_ID = ID;
                JiangFa.DeleJiangFaTypes(model);
                GetAllJiangFaTypes();
            }
        }
        #endregion 

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

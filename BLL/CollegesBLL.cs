using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;
using System.Windows.Forms;

namespace BLL
{
    //业务类
    public class CollegesBLL
    {
        #region 添加学院业务方法
        /// <summary>
        /// 添加学院业务方法
        /// </summary>
        /// <param name="model">学院的实体对象</param>
        public void AddColleges(CollegesModel model)
        {
            CollegesDAL College = new CollegesDAL();
            College.AddCollege(model);
        }
        #endregion

        #region 删除学院业务方法
        /// <summary>
        /// 删除学院业务方法
        /// </summary>
        /// <param name="model">学院的实体对象</param>
        public void DeleColleges(CollegesModel model)
        {
            CollegesDAL College = new CollegesDAL();
            College.DeleCollege(model);
        }
        #endregion

        #region 修改学院业务方法
        /// <summary>
        /// 修改学院业务方法
        /// </summary>
        /// <param name="model">学院的实体对象</param>
        public void UPColleges(CollegesModel model)
        {
            CollegesDAL College = new CollegesDAL();
            College.UPCollege(model);
        }
        #endregion

        #region 查询所有学院信息
        /// <summary>
        /// 查询所有学院信息
        /// </summary>
        /// <returns>DataTable数据表</returns>
        public DataTable GetAllColleges()
        {
            CollegesDAL College = new CollegesDAL();
            DataTable dt = College.GetAllColleges();
            return dt;
        }
        #endregion

        #region 检测学院编号是否存在
        /// <summary>
        /// 检测学院编号是否存在
        /// </summary>
        /// <param name="model">学院的实体对象</param>
        public bool SeleColleges(CollegesModel model)
        {
            CollegesDAL College = new CollegesDAL();
            bool b= College.SeleCollege(model);
            return b;
        }
        #endregion

        #region 按照编号查询
        /// <summary>
        /// 按照编号查询
        /// </summary>
        /// <param name="model">学院的实体对象</param>
        /// <returns>DataTable数据表</returns>
        public DataTable GetIDColleges(CollegesModel model)
        {
            CollegesDAL College = new CollegesDAL();
            DataTable dt = College.GetIDColleges(model);
            return dt;
        }
        #endregion

        #region 按照名称查询
        /// <summary>
        /// 按照名称查询
        /// </summary>
        /// <param name="model">学院的实体对象</param>
        /// <returns>DataTable数据表</returns>
        public DataTable GetNameColleges(CollegesModel model)
        {
            CollegesDAL College = new CollegesDAL();
            DataTable dt = College.GetNameColleges(model);
            return dt;
        }
        #endregion


    }
}

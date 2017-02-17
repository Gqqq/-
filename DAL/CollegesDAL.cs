using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CollegesDAL
    {
        #region 添加学院的数据访问方法
        /// <summary>
        /// 添加学院的数据访问方法
        /// </summary>
        /// <param name="model">学院的实体对象</param>
        public void AddCollege(CollegesModel model)
        {
            string sql = "insert into Colleges values(@0,@1)";
            SqlHelper.ExNonQuery(sql, "添加学院", model.College_ID, model.College_Name);
        }
        #endregion

        #region 删除学院的数据访问方法
        /// <summary>
        /// 删除学院的数据访问方法
        /// </summary>
        /// <param name="model">学院的实体对象</param>
        public void DeleCollege(CollegesModel model)
        {
            string sql = "delete Colleges where College_ID=@0";
            SqlHelper.ExNonQuery(sql,"删除学院",model.College_ID);
        }
        #endregion

        #region 修改学院的数据访问方法
        /// <summary>
        /// 修改学院的数据访问方法
        /// </summary>
        /// <param name="model">学院的实体对象</param>
        public void UPCollege(CollegesModel model)
        {
            string sql = "update Colleges set College_Name=@0 where College_ID=@1";
            SqlHelper.ExNonQuery(sql,"修改学院信息",model.College_Name,model.College_ID);
        }
        #endregion

        #region 查询所有学院信息的数据访问方法
        /// <summary>
        /// 查询所有学院信息的数据访问方法
        /// </summary>
        /// <returns>DataTable数据表</returns>
        public DataTable GetAllColleges()
        {
            string sql = "select College_ID 学院编号,College_Name 学院名称 from Colleges";
            DataTable dt = SqlHelper.GetDataTable(sql);
            return dt;
        }
        #endregion

        #region 检测学院是否存在的数据访问方法
        /// <summary>
        /// 检测学院是否存在的数据访问方法
        /// </summary>
        /// <param name="model">学院的实体对象</param>
        /// <returns>是或否</returns>
        public bool SeleCollege(CollegesModel model)
        {
            string sql = "select College_ID 学院编号,College_Name 学院名称 from Colleges where College_ID=@0";
            SqlDataReader dr = SqlHelper.ExReader(sql, model.College_ID);
            bool b= dr.Read();
            dr.Close();
            return b;
        }
        #endregion

        #region 按编号查询学院信息
        /// <summary>
        /// 按编号查询学院信息
        /// </summary>
        /// <param name="model">学院的实体对象</param>
        /// <returns>DataTable数据表</returns>
        public DataTable GetIDColleges(CollegesModel model)
        {
            string sql = "select College_ID 学院编号,College_Name 学院名称 from Colleges where College_ID like @0";
            DataTable dt = SqlHelper.GetDataTable(sql, model.College_ID);
            return dt;
        }
        #endregion

        #region 按名称查询学院信息
        /// <summary>
        /// 按名称查询学院信息
        /// </summary>
        /// <param name="model">学院的实体对象</param>
        /// <returns>DataTable数据表</returns>
        public DataTable GetNameColleges(CollegesModel model)
        {
            string sql = "select College_ID 学院编号,College_Name 学院名称 from Colleges where College_Name like @0";
            DataTable dt = SqlHelper.GetDataTable(sql, model.College_Name);
            return dt;
        }
        #endregion
    }
}

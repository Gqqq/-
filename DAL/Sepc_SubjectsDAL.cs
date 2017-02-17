using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Model;
using System.Data.SqlClient;
namespace DAL
{
    public class Sepc_SubjectsDAL
    {
        #region 为专业添加学科的数据访问方法
        /// <summary>
        /// 为专业添加学科的数据访问方法
        /// </summary>
        /// <param name="model">专业学科的实体对象</param>
        public void AddSepc_Subjects(Sepc_SubjectsModel model)
        {
            string sql = "insert into Sepc_Subjects values(@0,@1)";
            SqlHelper.ExNonQuery(sql, "为专业添加学科", model.Sepc_ID, model.Subjects_ID);
        }
        #endregion

        #region 为专业删除学科的数据访问方法
        /// <summary>
        /// 为专业删除学科的数据访问方法
        /// </summary>
        /// <param name="model">专业学科的实体对象</param>
        public void DeleSepc_Subjects(Sepc_SubjectsModel model)
        {
            string sql = "delete Sepc_Subjects where Sepc_ID=@0 and Subjects_ID=@1";
            SqlHelper.ExNonQuery(sql, "专业删除学科", model.Sepc_ID, model.Subjects_ID);
        }
        #endregion

        #region 查询专业所有学科
        /// <summary>
        /// 查询专业所有学科
        /// </summary>
        /// <param name="model">专业学科的实体对象</param>
        /// <returns>DataTable数据表</returns>
        public DataTable GetAllSepc_Subjects(Sepc_SubjectsModel model)
        {
            string sql = "select b.Subjects_ID 学科编号,Subjects_Name 学科名称 from Sepc_Subjects a  join Subjects b on a.Subjects_ID=b.Subjects_ID where Sepc_ID=@0";
            DataTable dt = SqlHelper.GetDataTable(sql,model.Sepc_ID);
            return dt;
        }
        #endregion

        #region 检测该专业下是否有该学科
        public bool SeleSepc_Subjects(Sepc_SubjectsModel model)
        {
            string sql = "select * from Sepc_Subjects where Sepc_ID=@0 and Subjects_ID=@1";
            SqlDataReader dr = SqlHelper.ExReader(sql, model.Sepc_ID, model.Subjects_ID);
            bool b = dr.Read();
            dr.Close();
            return b;

        }
        #endregion 
    }
}

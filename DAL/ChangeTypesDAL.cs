using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Model;

namespace DAL
{
    /// <summary>
    /// 学籍异动类型数据访问类
    /// </summary>
     public class ChangeTypesDAL
     {
         
         #region 添加学籍异动类型的数据访问方法
         /// <summary>
        /// 添加学籍异动类型的数据访问方法
         /// </summary>
        /// <param name="model">学籍异动类型的实体对象</param>
         public void AddChangeTypes(ChangeTypesModel model)
         {
             string sql = "insert into ChangeTypes values(@0)";
             SqlHelper.ExNonQuery(sql, "添加学籍异动类型", model.ChangeTypes_Name);
         }
        #endregion

         #region 删除学籍异动类型的数据访问方法
         /// <summary>
         /// 删除学籍异动类型的数据访问方法
         /// </summary>
         /// <param name="model">学籍异动类型的实体对象</param>
         public void DeteChangeTypes(ChangeTypesModel model)
         {
             string sql = "delete ChangeTypes where ChangeTypes_ID=@0";
             DataTable dt = SqlHelper.GetDataTable(sql,model.ChangeTypes_ID);
         }
         #endregion

         #region 查询学籍异动类型的数据访问方法
         /// <summary>
         /// 查询学籍异动类型的数据访问方法
         /// </summary>
         /// <returns>DataTable可修改的数据表</returns>
         public DataTable GetAllChangeTypes()
         {
             string sql = "select ChangeTypes_ID 异动类型编号,ChangeTypes_Name 异动类型名称 from ChangeTypes";
             DataTable dt = SqlHelper.GetDataTable(sql);
             return dt;
         }
         #endregion
     }
}

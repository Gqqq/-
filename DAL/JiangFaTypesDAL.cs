using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace DAL
{
    /// <summary>
    /// 奖罚类型数据访问类
    /// </summary>
     public class JiangFaTypesDAL
     {
         #region 添加奖罚类型的数据访问方法
         /// <summary>
         /// 添加奖罚类型的数据访问方法
        /// </summary>
         /// <param name="model">奖罚类型的实体对象</param>
         public void AddJiangFaTypes(JiangFaTypesModel model)
        {
            string sql = "insert into PunishmentAwardTypes values(@0,@1)";
            SqlHelper.ExNonQuery(sql, "添加奖罚类型", model.PunishmentAwardTypes_ID, model.PunishmentAwardTypes_Name);
        }
        #endregion

         #region 查询所有奖罚类型的数据访问方法
         /// <summary>
         /// 查询所有奖罚类型的数据访问方法
         /// </summary>
         /// <returns>奖罚类型的数据表</returns>
         public DataTable GetAllJiangFaTypes()
         {
             string sql = "select PunishmentAwardTypes_ID 奖罚类型编号,PunishmentAwardTypes_Name 奖罚类型名称 from PunishmentAwardTypes";
             DataTable dt = SqlHelper.GetDataTable(sql);
             return dt;
         }
         #endregion

         #region 删除奖罚类型的数据访问方法
         /// <summary>
         /// 删除奖罚类型的数据访问方法
         /// </summary>
         /// <param name="model">奖罚类型的实体对象</param>
         public void DeleJiangFaTypes(JiangFaTypesModel model)
         {
             string sql = "delete PunishmentAwardTypes where PunishmentAwardTypes_ID=@0";
             SqlHelper.ExNonQuery(sql, "删除奖罚类型", model.PunishmentAwardTypes_ID);
         }
         #endregion

         #region 查询奖罚类型编号最大的数据访问方法
         /// <summary>
         /// 查询奖罚类型编号最大的数据访问方法
         /// </summary>
         /// <returns>奖罚类型编号最大的数据</returns>
         public object GetMaxJiangFaTypes()
         {
             string sql = "select max(PunishmentAwardTypes_ID) from PunishmentAwardTypes";
             object o = SqlHelper.ExScalar(sql);
             return o;
         }
         #endregion

         #region 查询奖罚类型编号最小的数据访问方法
         /// <summary>
         /// 查询奖罚类型编号最小的数据访问方法
         /// </summary>
         /// <returns>奖罚类型编号最小的数据</returns>
         public object GetMinJiangFaTypes()
         {
             string sql = "select min(PunishmentAwardTypes_ID) from PunishmentAwardTypes";
             object o = SqlHelper.ExScalar(sql);
             return o;
         }
         #endregion

         /// <summary>
         /// 查询指定学生奖励记录
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
         public DataTable GetJiangTypes(JiangFaTypesModel model)
         {
             string sql = "select * from PunishmentAwardTypes where  PunishmentAwardTypes_ID>0";
             return SqlHelper.GetDataTable(sql);
         }
         /// <summary>
         /// 查询指定学生惩罚记录
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
         public DataTable GetFaTypes(JiangFaTypesModel model)
         {
             string sql = "select * from PunishmentAwardTypes where  PunishmentAwardTypes_ID<0";
             return SqlHelper.GetDataTable(sql);
         }
     }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using Model;

namespace BLL
{
    /// <summary>
    /// 创建奖罚类型业务类
    /// </summary>
     public class JiangFaTypesBLL
    {
        //全局变量JiangFa
         JiangFaTypesDAL JiangFa = new JiangFaTypesDAL();

         #region 添加奖罚类型的业务方法
         /// <summary>
         /// 添加奖罚类型的业务方法
         /// </summary>
         /// <param name="model">奖罚类型的实体对象</param>
         public void AddJiangFaTypes(JiangFaTypesModel model)
         {
             JiangFa.AddJiangFaTypes(model);
         }
         #endregion

         #region 删除奖罚类型的业务方法
         /// <summary>
         /// 删除奖罚类型的业务方法
         /// </summary>
         /// <param name="model">奖罚类型的实体对象</param>
         public void DeleJiangFaTypes(JiangFaTypesModel model)
         {
             JiangFa.DeleJiangFaTypes(model);
         }

        #endregion 

         #region 查询所有奖罚类型的业务方法
         /// <summary>
         /// 查询所有奖罚类型的业务方法
         /// </summary>
         /// <returns>DataTable可修改的数据表</returns>
         public DataTable GetAllJiangFaTypes()
         {
             DataTable dt = JiangFa.GetAllJiangFaTypes();
             return dt;
         }
        #endregion 

         #region 查询奖罚类型编号最大的业务方法
         /// <summary>
         /// 查询奖罚类型编号最大的业务方法
         /// </summary>
         /// <returns>第一行第一列的值</returns>
         public object GetMaxJiangFaTypes()
         {
             object o = JiangFa.GetMaxJiangFaTypes();
             return o;
         }
        #endregion 

         #region 查询奖罚类型编号最小的业务方法
         /// <summary>
         /// 查询奖罚类型编号最小的业务方法
         /// </summary>
         /// <returns>第一行第一列的值</returns>
         public object GetMinJiangFaTypes()
         {
             object o = JiangFa.GetMinJiangFaTypes();
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
             return JiangFa.GetJiangTypes(model);
         }
         /// <summary>
         /// 查询指定学生惩罚记录
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
         public DataTable GetFaTypes(JiangFaTypesModel model)
         {
             return JiangFa.GetFaTypes(model);
         }
    }
}

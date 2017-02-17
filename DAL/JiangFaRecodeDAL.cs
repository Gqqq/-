using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace DAL
{
   public class JiangFaRecodeDAL
    {
       /// <summary>
       /// 添加奖罚记录
       /// </summary>
       /// <param name="model"></param>
       public void AddJingFa(JiangFaModel model)
       {
           string sql = "insert into PunishmentAwardsRecode values(@0,@1,@2,@3,@4)";
           SqlHelper.ExNonQuery(sql, "添加奖罚记录", model.PunishmentAwardsType_ID, model.PunishmentAwardsStudentID, model.PunishmentAwardsContent, model.PunishmentAwardsReason, model.PunishmentAwardsDate);
       }
       /// <summary>
       /// 删除奖罚记录
       /// </summary>
       /// <param name="model"></param>
       public void DelJiangFa(JiangFaModel model)
       {
           string sql = "delete PunishmentAwardsRecode where PunishmentAwardsRecode_ID=@0";
           SqlHelper.ExNonQuery(sql, "删除奖罚记录", model.PunishmentAwardsRecode_ID);
       }
       ///// <summary>
       ///// 查询指定学生奖励记录
       ///// </summary>
       ///// <param name="model"></param>
       ///// <returns></returns>
       //public DataTable GetJiangRecodeByStudent(JiangFaModel model)
       //{
       //    string sql = "select * from PunishmentAwardTypes where PunishmentAwardTypes_ID=@0 and PunishmentAwardTypes_ID>0";
       //    return SqlHelper.GetDataTable(sql, model.PunishmentAwardsStudent_ID);
       //}
       ///// <summary>
       ///// 查询指定学生惩罚记录
       ///// </summary>
       ///// <param name="model"></param>
       ///// <returns></returns>
       //public DataTable GetFaRecodeByStudent(JiangFaModel model)
       //{
       //    string sql = "select * from PunishmentAwardTypes where PunishmentAwardTypes_ID=@0 and PunishmentAwardTypes_ID<0";
       //    return SqlHelper.GetDataTable(sql, model.PunishmentAwardsStudent_ID);
       //}
       /// <summary>
       /// 查询指定学生奖励记录
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public DataTable GetJiangRecodeByStudent(JiangFaModel model)
       {
           string sql = "select PunishmentAwardsRecode_ID 奖励编号,PunishmentAwardsType_ID 奖励类型编号,PunishmentAwardStudentID 学生编号,PunishmentAwardContent 奖励内容,PunishmentAwardReason 奖励原因,PunishmentAwardDate 奖励时间 from PunishmentAwardsRecode where PunishmentAwardStudentID=@0 and PunishmentAwardsType_ID>0";
           return SqlHelper.GetDataTable(sql, model.PunishmentAwardsStudentID);
       }
       /// <summary>
       /// 查询指定学生惩罚记录
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public DataTable GetFaRecodeByStudent(JiangFaModel model)
       {
           string sql = "select PunishmentAwardsRecode_ID 处罚编号,PunishmentAwardsType_ID 处罚类型编号,PunishmentAwardStudentID 学生编号,PunishmentAwardContent 处罚内容,PunishmentAwardReason 处罚原因,PunishmentAwardDate 处罚时间 from PunishmentAwardsRecode where PunishmentAwardStudentID=@0 and PunishmentAwardsType_ID<0";
           return SqlHelper.GetDataTable(sql, model.PunishmentAwardsStudentID);
       }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace DAL
{
   public class ChangeRecodeDAL
    {
        /// <summary>
        /// 获取指定学生异动记录
        /// </summary>
        /// <param name="model">异动记录实体对象</param>
        /// <returns></returns>
        public DataTable GetChangeRecodeByStudent(ChangeTypesRecodeModel model)
        {
            string sql = "select * from ChangeTypesRecode where ChangeStudentID=@0";
            return SqlHelper.GetDataTable(sql, model.ChangeStudentID);
        }
       /// <summary>
       /// 添加学籍异动信息
       /// </summary>
       /// <param name="model"></param>
        public void AddChangeRecode(ChangeTypesRecodeModel model)
        {
            string sql = "insert into ChangeTypesRecode values(@0,@1,@2,@3)";
            SqlHelper.ExNonQuery(sql,"添加学籍异动信息",model.ChangeTypes_ID,model.ChangeReason ,model.ChangeStudentID,model.ChangeDate);
        }
       /// <summary>
       /// 根据学号查询某学生异动信息
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        public DataTable GetAllChangeTypeRecode(ChangeTypesRecodeModel model)
        {
            string sql = "select ChangeTypesRecode_ID 异动编号, ChangeReason 异动原因,ChangeDate 异动时间,ChangeTypes_Name 异动类型 from ChangeTypes a join ChangeTypesRecode b on a.ChangeTypes_ID=b.ChangeTypes_ID where ChangeStudentID=@0";
            DataTable dt = SqlHelper.GetDataTable(sql,model.ChangeStudentID);
            return dt;
        }
       /// <summary>
        /// 删除异动信息
       /// </summary>
       /// <param name="model"></param>

        public void DelAllChangeRecode(ChangeTypesRecodeModel model)
        {
            string sql = "delete ChangeTypesRecode where ChangeTypesRecode_ID=@0";
            SqlHelper.ExNonQuery(sql, "删除异动信息", model.ChangeTypesRecode_ID);
        }
    }
}

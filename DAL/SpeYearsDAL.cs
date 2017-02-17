using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    //数据访问类
     public class SpeYearsDAL
     {
         #region 添加学制的数据访问方法
         /// <summary>
         /// 添加学制的数据访问方法
         /// </summary>
         /// <param name="model">学制实体对象</param>
         public void AddSpeYears(SpeYearsModel model)
         {
             string sql = "insert into SpeYears values(@0,@1)";
             SqlHelper.ExNonQuery(sql,"添加学制",model.SpeYears_Name,model.SpeYears_Years);
         }
        #endregion

         #region 删除学制的数据访问方法
         /// <summary>
         /// 删除学制的数据访问方法
         /// </summary>
         /// <param name="model">学制实体对象</param>
         public void DeleSpeYears(SpeYearsModel model)
         {
             string sql = "delete SpeYears where SpeYears_ID=@0";
             SqlHelper.ExNonQuery(sql, "删除学制",model.SpeYears_ID);
         }
         #endregion

         #region 查询所有学制信息的数据访问方法
         /// <summary>
         /// 查询所有学制信息的数据访问方法
         /// </summary>
         /// <returns>datatable数据表</returns>
         public DataTable GetAllSpeYears()
         {
             string sql = "select SpeYears_ID 学制编号,SpeYears_Name 学制名称,SpeYears_Years 学制时间 from SpeYears";
             DataTable dt = SqlHelper.GetDataTable(sql);
             return dt;
         }
         #endregion
         
         /// <summary>
         /// 根据专业查询所属学制名称
         /// </summary>
         /// <param name="model">专业实体对象</param>
         /// <returns></returns>
         public DataTable GetSpeyearbySpeciality(SpecialityModel model)
         {
             string sql = "select b.* from Speciality a join SpeYears b on a.Speciality_Years=b.SpeYears_ID where Speciality_ID=@0";
             return SqlHelper.GetDataTable(sql, model.Speciality_ID);
         }
         
     }
}

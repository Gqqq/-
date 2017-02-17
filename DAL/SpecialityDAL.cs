using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    ////数据访问类
     public class SpecialityDAL
     {
         #region 添加专业的数据访问方法
         /// <summary>
        /// 添加专业的数据访问方法
        /// </summary>
         /// <param name="model">专业实体对象</param>
         public void AddSpeciality(SpecialityModel model)
        {
            string sql = "insert into Speciality values(@0,@1,@2,@3)";
            SqlHelper.ExNonQuery(sql, "添加专业",model.Speciality_ID,model.Speciality_Name,model.Speciality_College,model.Speciality_Years);
        }
        #endregion

         #region 修改专业信息的数据访问方法
         /// <summary>
         ///修改专业信息的数据访问方法
         /// </summary>
         /// <param name="model">专业实体对象</param>
         public void UPSpeciality(SpecialityModel model)
         {
             string sql = "update Speciality set Speciality_Name=@0,Speciality_Years=@1 where Speciality_ID=@2";
             SqlHelper.ExNonQuery(sql, "修改专业", model.Speciality_Name, model.Speciality_Years, model.Speciality_ID);
         }
         #endregion

         #region 删除专业信息的数据访问方法
         /// <summary>
         /// 删除专业信息的数据访问方法
         /// </summary>
         /// <param name="model">专业实体对象</param>
         public void DeleSpeciality(SpecialityModel model)
         {
             string sql = "delete Speciality where Speciality_ID=@0";
             SqlHelper.ExNonQuery(sql, "删除专业",model.Speciality_ID);
         }
         #endregion

         #region 查询所有专业信息
         /// <summary>
         /// 查询所有专业信息
         /// </summary>
         /// <returns>DataTable数据表</returns>
         public DataTable GetAllSpeciality()
         {
             string sql = "select Speciality_ID 专业编号,Speciality_Name 专业名称,College_Name 所属学院,SpeYears_Name 学制 from Speciality a join Colleges b on a.Speciality_College=b.College_ID join SpeYears c on a.Speciality_Years=SpeYears_ID";
             DataTable dt = SqlHelper.GetDataTable(sql);
             return dt;
         }
         #endregion

         #region 检测专业编号
         /// <summary>
         /// 检测专业编号
         /// </summary>
         /// <param name="model">专业实体对象</param>
         /// <returns>是 否</returns>
         public bool SeleSpeciality(SpecialityModel model)
         {
             string sql = "select * from Speciality where Speciality_ID=@0";
             SqlDataReader dr = SqlHelper.ExReader(sql, model.Speciality_ID);
             bool b = dr.Read();
             dr.Close();
             return b;
         }
         #endregion

         #region 按照编号查询
         /// <summary>
         /// 按照编号查询
         /// </summary>
         /// <param name="model">专业实体对象</param>
         /// <returns>DataTable数据表</returns>
         public DataTable GetIdSpeciality(SpecialityModel model)
         {
             string sql = "select Speciality_ID 专业编号,Speciality_Name 专业名称,College_Name 所属学院,SpeYears_Name 学制 from Speciality a join Colleges b on a.Speciality_College=b.College_ID join SpeYears c on a.Speciality_Years=SpeYears_ID where Speciality_ID like @0";
             DataTable dt = SqlHelper.GetDataTable(sql, model.Speciality_ID);
             return dt;
         }
         #endregion

         #region 按照名称查询
         /// <summary>
         /// 按照名称查询
         /// </summary>
         /// <param name="model">专业实体对象</param>
         /// <returns>DataTable数据表</returns>
         public DataTable GetNameSpeciality(SpecialityModel model)
         {
             string sql = "select Speciality_ID 专业编号,Speciality_Name 专业名称,College_Name 所属学院,SpeYears_Name 学制 from Speciality a join Colleges b on a.Speciality_College=b.College_ID join SpeYears c on a.Speciality_Years=SpeYears_ID where Speciality_Name like @0";
             DataTable dt = SqlHelper.GetDataTable(sql, model.Speciality_Name);
             return dt;
         }
         #endregion



     }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Model;

namespace DAL
{
    //数据访问类
     public class TeacherDAL
     {
         #region 添加教师的数据访问方法
         /// <summary>
        /// 添加教师的数据访问方法
         /// </summary>
        /// <param name="model">教师的实体对象</param>
         public void AddTeacher(TeachersModel model)
         {
             string sql = "insert into Teachers values(@0,@1,@2,@3,@4,@5)";
             SqlHelper.ExNonQuery(sql, "添加教师", model.Teacher_Name, model.Teacher_Tel, model.Teacher_Sex, model.Teacher_InDate, model.Teacher_Birthday, model.Teacher_Origin);
         }
         #endregion

         #region 删除教师的数据访问方法
         /// <summary>
         /// 删除教师的数据访问方法
         /// </summary>
         /// <param name="model">教师的实体对象</param>
         public void DeleTeacher(TeachersModel model)
         {
             string sql = "delete Teachers where Teacher_ID=@0";
             SqlHelper.ExNonQuery(sql, "删除教师",model.Teacher_ID);
         }
         #endregion

         #region 修改教师的数据访问方法
         /// <summary>
         /// 修改教师的数据访问方法
         /// </summary>
         /// <param name="model">教师的实体对象</param>
         public void UPTeacher(TeachersModel model)
         {
             string sql = "update Teachers set Teacher_Name=@0,Teacher_Tel=@1,Teacher_Sex=@2,Teacher_InDate=@3,Teacher_Birthday=@4,Teacher_Origin=@5 where Teacher_ID=@6";
             SqlHelper.ExNonQuery(sql, "修改教师", model.Teacher_Name, model.Teacher_Tel, model.Teacher_Sex, model.Teacher_InDate, model.Teacher_Birthday, model.Teacher_Origin,model.Teacher_ID);
         }
         #endregion

         #region 查询所有教师信息的数据访问方法
         /// <summary>
         /// 查询所有教师信息的数据访问方法
         /// </summary>
         /// <returns>DataTable数据表</returns>
         public DataTable GetAllTeacher()
         {
             string sql = "select Teacher_ID 教师编号,Teacher_Name 教师姓名, Teacher_Tel 教师电话 ,Teacher_Sex 教师性别,Teacher_InDate 入职日期,Teacher_Birthday 教师生日, Teacher_Origin 教师籍贯 from Teachers";
             DataTable dt = SqlHelper.GetDataTable(sql);
             return dt;
         }
         #endregion
     }
}

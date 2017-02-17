using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
     public class ClassesDAL
     {
         #region 添加班级
         /// <summary>
         /// 添加班级
         /// </summary>
         /// <param name="model">班级的实体对象</param>
         public void AddClasses(ClassesModel model)
         {
             string sql = "insert into Classes values(@0,@1,@2,@3)";
             SqlHelper.ExNonQuery(sql, "添加班级", model.Classes_ID, model.Classes_Name, model.Classes_Speciality, model.ClassHeadTeacher);
         }
         #endregion

         #region 删除班级
         /// <summary>
         /// 删除班级
         /// </summary>
         /// <param name="model">班级的实体对象</param>
         public void DeleClasses(ClassesModel model)
         {
             string sql = "delete Classes where Classes_ID=@0";
             SqlHelper.ExNonQuery(sql, "删除班级", model.Classes_ID);
         }
         #endregion

         #region 修改班级
         /// <summary>
         /// 修改班级
         /// </summary>
         /// <param name="model">班级的实体对象</param>
         public void UPClasses(ClassesModel model)
         {
             string sql = "update Classes set Classes_Name=@0,ClassHeadTeacher=@1 where Classes_ID=@2";
             SqlHelper.ExNonQuery(sql, "修改班级", model.Classes_Name,model.ClassHeadTeacher, model.Classes_ID);
         }
         #endregion

         #region 查询所有班级
         /// <summary>
         /// 查询所有班级
         /// </summary>
         /// <returns>DataTable数据表</returns>
         public DataTable GetAllClasses()
         {
             string sql = "select Classes_ID 班级编号,Classes_Name 班级名称, Speciality_Name 所属专业,Teacher_Name 班主任 from Classes a join Speciality b on a.Classes_Speciality=b.Speciality_ID join Teachers c on a.ClassHeadTeacher=c.Teacher_ID";
             DataTable dt = SqlHelper.GetDataTable(sql);
             return dt;
         }
         #endregion

         #region 检测班级编号
         /// <summary>
         /// 检测班级编号
         /// </summary>
         /// <param name="model">班级的实体对象</param>
         /// <returns>是否</returns>
         public bool SeleClasses(ClassesModel model)
         {
             string sql = "select * from Classes where Classes_ID=@0";
             SqlDataReader dr = SqlHelper.ExReader(sql, model.Classes_ID);
             bool b = dr.Read();
             dr.Close();
             return b;
         }
         #endregion

         #region 根据学院查询班级
         /// <summary>
         /// 根据学员查询班级
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
         public DataTable GetClassesBySpeciality(ClassesModel model)
         {
             string sql = "select * from Classes where Classes_Speciality=@0";
             return SqlHelper.GetDataTable(sql, model.Classes_Speciality);
         }
         #endregion

         #region 模糊查询班级信息
         /// <summary>
         /// 根据班级名称模糊搜索班级信息
         /// </summary>
         /// <param name="model">班级实体对象</param>
         /// <returns>班级信息</returns>
         public DataTable GetClassesByClassName(ClassesModel model)
         {
             string sql = "select a.Classes_ID 班级编号,a.Classes_Name 班级名称,b.Speciality_Name 专业名称,d.College_Name 学院名称,Teacher_Name 班主任名称 from Classes a join Speciality b on a.Classes_Speciality=b.Speciality_ID join Teachers c on a.ClassHeadTeacher=c.Teacher_ID join Colleges d on b.Speciality_College=d.College_ID where  a.Classes_Name like '%'+@0+'%'";
             return SqlHelper.GetDataTable(sql, model.Classes_Name);
         }
         /// <summary>
         /// 根据专业名称模糊搜索班级信息
         /// </summary>
         /// <param name="model">专业实体对象</param>
         /// <returns>班级信息</returns>
         public DataTable GetClassesBySpecialityName(SpecialityModel model)
         {
             string sql = "select a.Classes_ID 班级编号,a.Classes_Name 班级名称,b.Speciality_Name 专业名称,d.College_Name 学院名称,Teacher_Name 班主任名称 from Classes a join Speciality b on a.Classes_Speciality=b.Speciality_ID join Teachers c on a.ClassHeadTeacher=c.Teacher_ID join Colleges d on b.Speciality_College=d.College_ID where  b.Speciality_Name like '%'+@0+'%'";
             return SqlHelper.GetDataTable(sql, model.Speciality_Name);
         }
         /// <summary>
         /// 根据学院名称模糊搜索班级信息
         /// </summary>
         /// <param name="model">班级实体对象</param>
         /// <returns>班级信息</returns>
         public DataTable GetClassesByCollegeName(CollegesModel model)
         {
             string sql = "select a.Classes_ID 班级编号,a.Classes_Name 班级名称,b.Speciality_Name 专业名称,d.College_Name 学院名称,Teacher_Name 班主任名称 from Classes a join Speciality b on a.Classes_Speciality=b.Speciality_ID join Teachers c on a.ClassHeadTeacher=c.Teacher_ID join Colleges d on b.Speciality_College=d.College_ID where  d.College_Name like '%'+@0+'%'";
             return SqlHelper.GetDataTable(sql, model.College_Name);
         }
         /// <summary>
         /// 根据班主任名称模糊搜索班级信息
         /// </summary>
         /// <param name="model">班主任实体对象</param>
         /// <returns>班级信息</returns>
         public DataTable GetClassesByTeacherName(TeachersModel model)
         {
             string sql = "select a.Classes_ID 班级编号,a.Classes_Name 班级名称,b.Speciality_Name 专业名称,d.College_Name 学院名称,Teacher_Name 班主任名称 from Classes a join Speciality b on a.Classes_Speciality=b.Speciality_ID join Teachers c on a.ClassHeadTeacher=c.Teacher_ID join Colleges d on b.Speciality_College=d.College_ID where  c.Teacher_Name like '%'+@0+'%'";
             return SqlHelper.GetDataTable(sql, model.Teacher_Name);
         }
         /// <summary>
         /// 根据班级名称和班主任名称模糊搜索班级信息
         /// </summary>
         /// <param name="model">班级实体对象</param>
         /// <param name="teamodel">班主任实体对象</param>
         /// <returns>班级信息</returns>
         public DataTable GetClassesByClassAndTeacher(ClassesModel clamodel, TeachersModel teamodel)
         {
             string sql = "select a.Classes_ID 班级编号,a.Classes_Name 班级名称,b.Speciality_Name 专业名称,d.College_Name 学院名称,Teacher_Name 班主任名称 from Classes a join Speciality b on a.Classes_Speciality=b.Speciality_ID join Teachers c on a.ClassHeadTeacher=c.Teacher_ID join Colleges d on b.Speciality_College=d.College_ID where  a.Classes_Name like '%'+@0+'%' and c.Teacher_Name like '%'+@1+'%'";
             return SqlHelper.GetDataTable(sql, clamodel.Classes_Name, teamodel.Teacher_Name);
         }
         /// <summary>
         /// 根据专业名称和班主任名称模糊搜索班级信息
         /// </summary>
         /// <param name="specmodel">专业实体对象</param>
         /// <param name="teamodel">班主任实体对象</param>
         /// <returns>班级信息</returns>
         public DataTable GetClassesBySpecialityAndTeacher(SpecialityModel specmodel, TeachersModel teamodel)
         {
             string sql = "select a.Classes_ID 班级编号,a.Classes_Name 班级名称,b.Speciality_Name 专业名称,d.College_Name 学院名称,Teacher_Name 班主任名称 from Classes a join Speciality b on a.Classes_Speciality=b.Speciality_ID join Teachers c on a.ClassHeadTeacher=c.Teacher_ID join Colleges d on b.Speciality_College=d.College_ID where  b.Speciality_Name like '%'+@0+'%' and c.Teacher_Name like '%'+@1+'%'";
             return SqlHelper.GetDataTable(sql, specmodel.Speciality_Name, teamodel.Teacher_Name);
         }
         /// <summary>
         /// 根据学院名称和班主任名称模糊搜索班级信息
         /// </summary>
         /// <param name="specmodel">学院实体对象</param>
         /// <param name="teamodel">班主任实体对象</param>
         /// <returns>班级信息</returns>
         public DataTable GetClassesByCollegeAndTeacher(CollegesModel collmodel, TeachersModel teamodel)
         {
             string sql = "select a.Classes_ID 班级编号,a.Classes_Name 班级名称,b.Speciality_Name 专业名称,d.College_Name 学院名称,Teacher_Name 班主任名称 from Classes a join Speciality b on a.Classes_Speciality=b.Speciality_ID join Teachers c on a.ClassHeadTeacher=c.Teacher_ID join Colleges d on b.Speciality_College=d.College_ID where  d.College_Name like '%'+@0+'%' and c.Teacher_Name like '%'+@1+'%'";
             return SqlHelper.GetDataTable(sql, collmodel.College_Name, teamodel.Teacher_Name);
         }
#endregion
     }
}

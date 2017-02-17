using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
   public class StudentsDAL
    {
       /// <summary>
       /// 增加学生数据访问方法
       /// </summary>
       /// <param name="model">学生实体对象</param>
       public void AddStudent(StudentsModel model)
       {
           string sql = "insert into Students values(@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12)";
           SqlHelper.ExNonQuery(sql, "添加学生信息",model.Student_Name, model.Student_Sex, model.StudentClass, model.StudentNum, model.StudentEnterYear, model.StudentOrigin, model.StudentBirthDay, model.StudentCard, model.StudentAddress, model.FamilyTel, model.DormTel, model.Mobile, model.Email);
       }
       /// <summary>
       /// 删除学生数据访问方法
       /// </summary>
       /// <param name="model">学生实体对象</param>
       public void DelStudent(StudentsModel model)
       {
           string sql = "delete Students where Student_ID=@0";
           SqlHelper.ExNonQuery(sql, "删除学生信息", model.Student_ID);
       }
       /// <summary>
       /// 修改学生数据访问方法
       /// </summary>
       /// <param name="model">学生实体对象</param>
       public void UpdateStudent(StudentsModel model)
       {
           string sql = "update Students set Student_Name=@0,Student_Sex=@1,StudentClass=@2,StudentNum=@3,StudentEnterYear=@4,StudentOrigin=@5,StudentBirthDay=@6,StudentCard=@7,StudentAddress=@8,FamilyTel=@9,DormTel=@10,Mobile=@11,Email=@12 where Student_ID=@13";
           SqlHelper.ExNonQuery(sql, "修改学生信息", model.Student_Name, model.Student_Sex, model.StudentClass, model.StudentNum, model.StudentEnterYear, model.StudentOrigin, model.StudentBirthDay, model.StudentCard, model.StudentAddress, model.FamilyTel, model.DormTel, model.Mobile, model.Email, model.Student_ID);
       }
       /// <summary>
       /// 检查学生编号
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public bool CheckStudent(StudentsModel model)
       {
           string sql = "select * from Students where StudentNum=@0";
           SqlDataReader dr = SqlHelper.ExReader(sql,model.StudentNum);
           bool b = dr.Read();
           dr.Close();
           return b;
       }
       /// <summary>
       /// 根据班级查询学生信息
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public DataTable GetStudentByClasses(StudentsModel model)
       {
           string sql = "select a.Student_ID,a.Student_Name,a.StudentNum,a.Student_Sex,a.StudentEnterYear,a.StudentOrigin,e.College_Name,c.Speciality_Name,d.SpeYears_Name from Students a join Classes b on a.StudentClass=b.Classes_ID join Speciality c on b.Classes_Speciality=c.Speciality_ID join SpeYears d on c.Speciality_Years=d.SpeYears_ID join Colleges e on c.Speciality_College=e.College_ID where a.StudentClass=@0";
           return SqlHelper.GetDataTable(sql, model.StudentClass); 
       }
       /// <summary>
       /// 根据学院查询学生信息
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public DataTable GetStudentsByCollege(SpecialityModel model)
       {
           string sql = "select a.*, e.College_Name,c.Speciality_Name,d.SpeYears_Name from Students a join Classes b on a.StudentClass=b.Classes_ID join Speciality c on b.Classes_Speciality=c.Speciality_ID join SpeYears d on c.Speciality_Years=d.SpeYears_ID join Colleges e on c.Speciality_College=e.College_ID where c.Speciality_College=@0";
           DataTable dt = SqlHelper.GetDataTable(sql, model.Speciality_College);
           return dt;
       }
       /// <summary>
       /// 根据专业查询学生信息
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public DataTable GetStudentsBySpec(ClassesModel model)
       {
           string sql = "select a.*, e.College_Name,c.Speciality_Name,d.SpeYears_Name from Students a join Classes b on a.StudentClass=b.Classes_ID join Speciality c on b.Classes_Speciality=c.Speciality_ID join SpeYears d on c.Speciality_Years=d.SpeYears_ID join Colleges e on c.Speciality_College=e.College_ID where b.Classes_Speciality=@0";
           DataTable dt = SqlHelper.GetDataTable(sql, model.Classes_Speciality);
           return dt;
       }
       /// <summary>
       /// 查询指定单个学生信息
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public DataTable GetStudentsByID(StudentsModel model)
       {
           string sql = "select a.*,b.*,c.*,d.*,e.* from Students a join Classes b on a.StudentClass=b.Classes_ID join Speciality c on b.Classes_Speciality=c.Speciality_ID join SpeYears d on c.Speciality_Years=d.SpeYears_ID join Colleges e on c.Speciality_College=e.College_ID where a.Student_ID=@0";
           return SqlHelper.GetDataTable(sql, model.Student_ID);
       }
       public DataTable GetStudentByName(StudentsModel model)
       {
           string sql = "select * from Students where Student_Name=@0";
           DataTable dt = SqlHelper.GetDataTable(sql, model.Student_Name);
           return dt;
       }
    }
}

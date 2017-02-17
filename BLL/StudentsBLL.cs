using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using Model;

namespace BLL
{

   public class StudentsBLL
    {
       StudentsDAL student = new StudentsDAL();
       /// <summary>
       /// 增加学生业务方法
       /// </summary>
       /// <param name="model">学生实体对象</param>
       public void AddStudents(StudentsModel model)
       {
           student.AddStudent(model);
       }
       /// <summary>
       /// 删除学生业务方法
       /// </summary>
       /// <param name="model"></param>
       public void DelStudents(StudentsModel model)
       {
           student.DelStudent(model);
       }
       /// <summary>
       /// 检查学生编号是否存在
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public bool CheckStudent(StudentsModel model)
       {
           return student.CheckStudent(model);
           
       }
       /// <summary>
       /// 根据班级查询学生信息
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public DataTable GetStudentByClasses(StudentsModel model)
       {
           return student.GetStudentByClasses(model);
       }
       /// <summary>
       /// 查询指定单个学生信息
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public DataTable GetStudentsByID(StudentsModel model)
       {
           return student.GetStudentsByID(model);
       }
       ///// <summary>
       ///// 获取指定学生异动记录
       ///// </summary>
       ///// <param name="model">异动记录实体对象</param>
       ///// <returns></returns>
       //public DataTable GetChangeRecodeByStudent(ChangeTypesRecodeModel model)
       //{
       //    return student.GetChangeRecodeByStudent(model);
       //}
       ///// <summary>
       ///// 查询指定学生获奖记录
       ///// </summary>
       ///// <param name="model"></param>
       ///// <returns></returns>
       //public DataTable GetJiangRecodeByStudent(JiangFaModel model)
       //{
       //    return student.GetJiangRecodeByStudent(model);
       //}
       ///// <summary>
       ///// 查询指定学生获奖记录
       ///// </summary>
       ///// <param name="model"></param>
       ///// <returns></returns>
       //public DataTable GetFaRecodeByStudent(JiangFaModel model)
       //{
       //    return student.GetFaRecodeByStudent(model);
       //}
       /// <summary>
       /// 修改学生业务方法
       /// </summary>
       /// <param name="model"></param>
       public void UpdateStudent(StudentsModel model)
       {
           student.UpdateStudent(model);
       }
       /// <summary>
       /// 根据学员查询学生信息
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public DataTable GetStudentsByCollege(SpecialityModel model)
       {
           return student.GetStudentsByCollege(model);
       }
       /// <summary>
       /// 根据专业查询学生信息
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public DataTable GetStudentsBySpec(ClassesModel model)
       {
           return student.GetStudentsBySpec(model);
       }
       /// <summary>
       /// 根据学生名字查询
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public DataTable GetStudentByName(StudentsModel model)
       {
           return student.GetStudentByName(model);
       }
    }
}

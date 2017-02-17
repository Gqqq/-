using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class ClassesBLL
    {
        ClassesDAL Class = new ClassesDAL();

        #region 添加班级
        /// <summary>
        /// 添加班级
        /// </summary>
        public void AddClasses(ClassesModel model)
        {
            Class.AddClasses(model);
        }
        #endregion

        #region 删除班级
        /// <summary>
        /// 删除班级
        /// </summary>
        public void DeleClasses(ClassesModel model)
        {
            Class.DeleClasses(model);
        }
        #endregion

        #region 修改班级
        /// <summary>
        /// 修改班级
        /// </summary>
        public void UPClasses(ClassesModel model)
        {
            Class.UPClasses(model);
        }
        #endregion

        #region 查询所有班级
        /// <summary>
        /// 查询所有班级
        /// </summary>
        /// <returns>DataTable数据表</returns>
        public DataTable GetAllClasses()
        {
            DataTable dt = Class.GetAllClasses();
            return dt;
        }
        #endregion

        #region 检测班级编号
        /// <summary>
        /// 检测班级编号
        /// </summary>
        /// <returns>是否</returns>
        public bool SeleClasses(ClassesModel model)
        {
            bool b = Class.SeleClasses(model);
            return b;
        }
        #endregion

        #region 根据专业查询班级
        public DataTable GetClassesBySpeciality(ClassesModel model)
        {
            DataTable dt = Class.GetClassesBySpeciality(model);
            return dt;
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
            return Class.GetClassesByClassName(model);
        }
        /// <summary>
        /// 根据专业名称模糊搜索班级信息
        /// </summary>
        /// <param name="model">专业实体对象</param>
        /// <returns>班级信息</returns>
        public DataTable GetClassesBySpecialityName(SpecialityModel model)
        {
            return Class.GetClassesBySpecialityName(model);
        }
        /// <summary>
        /// 根据学院名称模糊搜索班级信息
        /// </summary>
        /// <param name="model">班级实体对象</param>
        /// <returns>班级信息</returns>
        public DataTable GetClassesByCollegeName(CollegesModel model)
        {
            return Class.GetClassesByCollegeName(model);
        }
        /// <summary>
        /// 根据班主任名称模糊搜索班级信息
        /// </summary>
        /// <param name="model">班主任实体对象</param>
        /// <returns>班级信息</returns>
        public DataTable GetClassesByTeacherName(TeachersModel model)
        {
            return Class.GetClassesByTeacherName(model);
        }
        /// <summary>
        /// 根据班级名称和班主任名称模糊搜索班级信息
        /// </summary>
        /// <param name="model">班级实体对象</param>
        /// <param name="teamodel">班主任实体对象</param>
        /// <returns>班级信息</returns>
        public DataTable GetClassesByClassAndTeacher(ClassesModel clamodel, TeachersModel teamodel)
        {
            return Class.GetClassesByClassAndTeacher(clamodel,teamodel);
        }
        /// <summary>
        /// 根据专业名称和班主任名称模糊搜索班级信息
        /// </summary>
        /// <param name="specmodel">专业实体对象</param>
        /// <param name="teamodel">班主任实体对象</param>
        /// <returns>班级信息</returns>
        public DataTable GetClassesBySpecialityAndTeacher(SpecialityModel specmodel, TeachersModel teamodel)
        {
            return Class.GetClassesBySpecialityAndTeacher(specmodel,teamodel);
        }
        /// <summary>
        /// 根据学院名称和班主任名称模糊搜索班级信息
        /// </summary>
        /// <param name="specmodel">学院实体对象</param>
        /// <param name="teamodel">班主任实体对象</param>
        /// <returns>班级信息</returns>
        public DataTable GetClassesByCollegeAndTeacher(CollegesModel collmodel, TeachersModel teamodel)
        {
            return Class.GetClassesByCollegeAndTeacher(collmodel,teamodel);
        }
        #endregion
    }
}

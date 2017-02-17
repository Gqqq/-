using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    //业务类
    public class TeacherBLL
    {
        TeacherDAL teacher = new TeacherDAL();

        #region 添加教师信息
        /// <summary>
        /// 添加教师信息
        /// </summary>
        /// <param name="model">教师的实体对象</param>
        public void AddTeacher(TeachersModel model)
        {
            teacher.AddTeacher(model);
        }
        #endregion

        #region 删除教师信息
        /// <summary>
        /// 删除教师信息
        /// </summary>
        /// <param name="model">教师的实体对象</param>
        public void DeleTeacher(TeachersModel model)
        {
            teacher.DeleTeacher(model);
        }
        #endregion

        #region 修改教师信息
        /// <summary>
        /// 修改教师信息
        /// </summary>
        /// <param name="model">教师的实体对象</param>
        public void UPTeacher(TeachersModel model)
        {
            teacher.UPTeacher(model);
        }
        #endregion

        #region 查询所有教师信息
        /// <summary>
        /// 查询所有教师信息
        /// </summary>
        /// <param name="model">教师的实体对象</param>
        public DataTable GetAllTeacher()
        {
          DataTable dt=teacher.GetAllTeacher();
          return dt;
        }
        #endregion
    }
}

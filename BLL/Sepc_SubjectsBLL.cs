using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using Model;

namespace BLL
{
    public class Sepc_SubjectsBLL
    {
        Sepc_SubjectsDAL Sepc_Subjects = new Sepc_SubjectsDAL();

        #region 为专业添加学科
        /// <summary>
        /// 为专业添加学科
        /// </summary>
        /// <param name="model">专业学科的实体对象</param>
        public void AddSepc_Subjects(Sepc_SubjectsModel model)
        {
            Sepc_Subjects.AddSepc_Subjects(model);
        }
        #endregion

        #region 删除专业下的学科
        /// <summary>
        /// 删除专业下的学科
        /// </summary>
        /// <param name="model">学科专业的实体对象</param>
        public void DeleSepc_Subjects(Sepc_SubjectsModel model)
        {
            Sepc_Subjects.DeleSepc_Subjects(model);
        }
        #endregion

        #region 获取专业下所有学科
        /// <summary>
        /// 获取专业下所有学科
        /// </summary>
        /// <param name="model">专业学科的实体对象</param>
        /// <returns>DataTable数据表</returns>
        public DataTable GetAllSepc_Subjects(Sepc_SubjectsModel model)
        {
           DataTable dt=Sepc_Subjects.GetAllSepc_Subjects(model);
           return dt;
        }
        #endregion

        #region 检测该专业下是否有该学科
        public bool SeleSepc_Subjects(Sepc_SubjectsModel model)
        {
         bool b=Sepc_Subjects.SeleSepc_Subjects(model);
         return b;
        }
        #endregion
    }
}

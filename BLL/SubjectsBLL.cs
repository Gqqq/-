using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using Model;

namespace BLL
{
    public class SubjectsBLL
    {
        SubjectsDAL subject = new SubjectsDAL();
        #region 添加科目业务
        /// <summary>
        /// 添加科目业务
        /// </summary>
        /// <param name="model">科目的实体对象</param>
        public void AddSubjects(SubjectsModel model)
        {
            SubjectsDAL subject = new SubjectsDAL();
            subject.AddSubjects(model);
        }
        #endregion

        #region 删除科目业务
        /// <summary>
        /// 删除科目业务
        /// </summary>
        /// <param name="model">科目的实体对象</param>
        public void DeleSubjects(SubjectsModel model)
        {
            SubjectsDAL subject = new SubjectsDAL();
            subject.DeleSubject(model);
        }
        #endregion
        
        #region 查询所有科目的业务访问方法
        /// <summary>
        /// 查询所有科目的业务访问方法
        /// </summary>
        /// <param name="model">科目的实体对象</param>
        /// <returns>DataTable的数据表</returns>
        public DataTable GetAllSubjects()
        {
            SubjectsDAL subject = new SubjectsDAL();
            DataTable dt = subject.GetAllSubjects();
            return dt;
        }
        #endregion

        public DataTable GetSubjectsBySpeciality(SpecialityModel model)
        {
            return subject.GetSubjectsBySpeciality(model);
        }

    }
}

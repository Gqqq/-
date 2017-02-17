using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Model;

namespace DAL
{
    public class SubjectsDAL
    {
        #region 添加科目的数据访问方法
        /// <summary>
        /// 添加科目的数据访问方法
        /// </summary>
        /// <param name="model">科目的实体对象</param>
        public void AddSubjects(SubjectsModel model)
        {
            string sql = "insert into Subjects values(@0)";
            SqlHelper.ExNonQuery(sql, "添加科目", model.Subjects_Name);
        }
        #endregion

        #region 删除科目的数据访问方法
        /// <summary>
        /// 删除科目的数据访问方法
        /// </summary>
        /// <param name="model">科目的实体对象</param>
        public void DeleSubject(SubjectsModel model)
        {
            string sql = "delete Subjects where Subjects_ID=@0";
            SqlHelper.ExNonQuery(sql, "删除科目",model.Subjects_ID);
        }
        #endregion

        #region 查询所有科目的数据访问方法
        /// <summary>
        /// 查询所有科目的数据访问方法
        /// </summary>
        /// <param name="model">科目的实体对象</param>
        /// <returns>DataTable数据表</returns>
        public DataTable GetAllSubjects()
        {
            string sql = "select Subjects_ID 科目编号,Subjects_Name 科目名称 from Subjects";
            DataTable dt = SqlHelper.GetDataTable(sql);
            return dt;
        }
        #endregion
        /// <summary>
        /// 根据专业查询学科
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetSubjectsBySpeciality(SpecialityModel model)
        {
            string sql = "select b.Subjects_ID,b.Subjects_Name from Sepc_Subjects a join Subjects b on a.Subjects_ID=b.Subjects_ID join Speciality c on a.Sepc_ID=Speciality_ID where c.Speciality_ID=@0";
            DataTable dt = SqlHelper.GetDataTable(sql, model.Speciality_ID);
            return dt;
        }
    }
}

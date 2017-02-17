using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class ExaminationBLL
    {
        ExaminationDAL exam = new ExaminationDAL();
        /// <summary>
        /// 添加学生成绩业务方法
        /// </summary>
        /// <param name="model"></param>
        public int AddExamination(int r,List<ExaminationModel> model)
        {
           return exam.AddExamination(r,model);
        }
        /// <summary>
        /// 修改学生成绩业务方法
        /// </summary>
        /// <param name="r"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateExamination(int r, List<ExaminationModel> model)
        {
            return exam.UpdateExamination(r,model);
        }
        /// <summary>
        /// 修改学生成绩业务方法
        /// </summary>
        /// <param name="model"></param>
        //public void UpdateExamination(ExaminationModel model)
        //{
        //    exam.UpdateExamination(model);
        //}
        /// <summary>
        /// 查询某学生所有成绩
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetGreadByStudent(ExaminationModel model)
        {
            return exam.GetGreadByStudent(model);
        }
        /// <summary>
        /// 在班级内按单科排名
        /// </summary>
        /// <param name="check">是否降序</param>
        /// <param name="classmodel">班级实体对象</param>
        /// <param name="submodel"></param>
        /// <returns></returns>
        public DataTable OrderBySingleClass(bool check, ClassesModel classmodel, SubjectsModel submodel)
        {
            return exam.OrderBySingleClass(check, classmodel, submodel);
        }
        /// <summary>
        /// 在专业内按单科排名
        /// </summary>
        /// <param name="check"></param>
        /// <param name="specmodel"></param>
        /// <param name="submodel"></param>
        /// <returns></returns>
        public DataTable OrderBySingleSpeciality(bool check, SpecialityModel specmodel, SubjectsModel submodel)
        {
            return exam.OrderBySingleSpeciality(check, specmodel, submodel);
        }
        /// <summary>
        /// 查询班级总成绩
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetAllGradeByClass(ClassesModel model)
        {
            return exam.GetAllGradeByClass(model);
        }
        /// <summary>
        /// 查询专业总成绩
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetAllGradeBySpeciality(SpecialityModel model)
        {
            return exam.GetAllGradeBySpeciality(model);
        }
    }
}

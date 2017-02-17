using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;


namespace DAL
{
    public class ExaminationDAL
    {
        /// <summary>
        /// 添加学生成绩
        /// </summary>
        /// <param name="model"></param>
        public int AddExamination(int r,List<ExaminationModel> model)
        {
            List<string> sqllist = new List<string>();//初始化一个List列表(命令列表)
            for (int i = 0; i < r; i++)
            {
                string sql = string.Format("insert into Examination values({0},{1},{2})", model[i].StudentID, model[i].SubjectsID, model[i].ExamScore);
                sqllist.Add(sql);
            }
            return SqlHelper.BeginTranExecNoneQuery(sqllist);
        }
        /// <summary>
        /// 修改学生成绩
        /// </summary>
        /// <param name="model"></param>
        public int UpdateExamination(int r, List<ExaminationModel> model)
        {
            List<string> sqllist = new List<string>();//初始化一个List列表(命令列表)
            for (int i = 0; i < r; i++)
            {
                string sql = string.Format("update Examination set ExamScore={0} where StudentID={1} and SubjectsID={2}",model[i].ExamScore, model[i].StudentID, model[i].SubjectsID);
                sqllist.Add(sql);
            }
            return SqlHelper.BeginTranExecNoneQuery(sqllist);
        }
        /// <summary>
        /// 修改学生成绩
        /// </summary>
        /// <param name="model"></param>
        //public void UpdateExamination(ExaminationModel model)
        //{
        //    string sql = "update Examination set ExamScore=@0 where StudentID=@0";
        //    SqlHelper.ExNonQuery(sql,"修改成绩",model.StudentID);
        //}
        /// <summary>
        /// 查询某学生所有成绩
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetGreadByStudent(ExaminationModel model)
        {
            string sql = "select * from Examination where StudentID=@0";
            return SqlHelper.GetDataTable(sql,model.StudentID);
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
            string sql = "";
            if (check == false)
            {
                sql = "select d.Classes_Name 班级名称,c.Subjects_Name 科目名称,b.StudentNum 学号,b.Student_Name 姓名,a.ExamScore 成绩 from Examination a join Students b on a.StudentID=b.Student_ID join Subjects c on a.SubjectsID=c.Subjects_ID join Classes d on b.StudentClass=d.Classes_ID where d.Classes_ID=@0 and c.Subjects_ID=@1 order by a.Examscore asc";
            }
            else
            {
                sql = "select d.Classes_Name 班级名称,c.Subjects_Name 科目名称,b.StudentNum 学号,b.Student_Name 姓名,a.ExamScore 成绩 from Examination a join Students b on a.StudentID=b.Student_ID join Subjects c on a.SubjectsID=c.Subjects_ID join Classes d on b.StudentClass=d.Classes_ID where d.Classes_ID=@0 and c.Subjects_ID=@1 order by a.Examscore desc";
            }
            return SqlHelper.GetDataTable(sql, classmodel.Classes_ID, submodel.Subjects_ID);
        }

        /// <summary>
        /// 在专业内按单科排名
        /// </summary>
        /// <param name="check"></param>
        /// <param name="classmodel"></param>
        /// <param name="submodel"></param>
        /// <returns></returns>
        public DataTable OrderBySingleSpeciality(bool check, SpecialityModel spemodel, SubjectsModel submodel)
        {
            string sql = "";
            if (check == false)
            {
                sql = "select b.Student_Name 学生姓名,b.StudentNum 学号,e.Speciality_Name 专业名称,c.Subjects_Name 科目名称,a.ExamScore 成绩 from Examination a join Students b on a.StudentID = b.Student_ID join Subjects c on a.SubjectsID = c.Subjects_ID join Classes d on b.StudentClass = d.Classes_ID join Speciality e on d.Classes_Speciality = e.Speciality_ID where Speciality_ID = @0 and c.Subjects_ID = @1 order by a.ExamScore asc";
            }
            else
            {
                sql = "select b.Student_Name 学生姓名,b.StudentNum 学号,e.Speciality_Name 专业名称,c.Subjects_Name 科目名称,a.ExamScore 成绩 from Examination a join Students b on a.StudentID = b.Student_ID join Subjects c on a.SubjectsID = c.Subjects_ID join Classes d on b.StudentClass = d.Classes_ID join Speciality e on d.Classes_Speciality = e.Speciality_ID where Speciality_ID = @0 and c.Subjects_ID = @1 order by a.ExamScore desc";
            }
            return SqlHelper.GetDataTable(sql, spemodel.Speciality_ID, submodel.Subjects_ID);
        }
        /// <summary>
        /// 按班级总成绩排名
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetAllGradeByClass(ClassesModel model)
        {
            string sql = "select a.* from Examination a join Students b on a.StudentID=b.Student_ID join Classes c on b.StudentClass=c.Classes_ID where c.Classes_ID=@0";
                return SqlHelper.GetDataTable(sql,model.Classes_ID);
        }
        /// <summary>
        /// 按专业总成绩排名
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetAllGradeBySpeciality(SpecialityModel model)
        {
            string sql = "select * from Examination a join Students b on a.StudentID=b.Student_ID join Classes c on b.StudentClass=c.Classes_ID join Speciality d on c.Classes_Speciality=d.Speciality_ID where d.Speciality_ID=@0";
            return SqlHelper.GetDataTable(sql, model.Speciality_ID);
        }
        
    }
}

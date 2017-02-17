using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 成绩表实体类Examination 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class ExaminationModel
    {
        #region Model
        private int _examination_id;
        private int? _studentid;
        private int? _subjectsid;
        private int? _examscore;
        /// <summary>
        /// 考试编号
        /// </summary>
        public int Examination_ID
        {
            set { _examination_id = value; }
            get { return _examination_id; }
        }
        /// <summary>
        /// 学生编号 
        /// </summary>
        public int? StudentID
        {
            set { _studentid = value; }
            get { return _studentid; }
        }
        /// <summary>
        /// 科目编号
        /// </summary>
        public int? SubjectsID
        {
            set { _subjectsid = value; }
            get { return _subjectsid; }
        }
        /// <summary>
        /// 考试成绩
        /// </summary>
        public int? ExamScore
        {
            set { _examscore = value; }
            get { return _examscore; }
        }
        #endregion Model

    }
}

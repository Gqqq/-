using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 班级表  实体类Classes 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class ClassesModel
    {
        #region Model
        private string _classes_id;
        private string _classes_name;
        private string _classes_speciality;
        private int? _classheadteacher;
        /// <summary>
        /// 班级编号
        /// </summary>
        public string Classes_ID
        {
            set { _classes_id = value; }
            get { return _classes_id; }
        }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string Classes_Name
        {
            set { _classes_name = value; }
            get { return _classes_name; }
        }
        /// <summary>
        /// 所属专业
        /// </summary>
        public string Classes_Speciality
        {
            set { _classes_speciality = value; }
            get { return _classes_speciality; }
        }
        /// <summary>
        /// 班主任老师编号
        /// </summary>
        public int? ClassHeadTeacher
        {
            set { _classheadteacher = value; }
            get { return _classheadteacher; }
        }
        #endregion Model

    }
}

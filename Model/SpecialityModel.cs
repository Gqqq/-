using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 专业表实体类Speciality 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class SpecialityModel
    {
        #region Model
        private string _speciality_id;
        private string _speciality_name;
        private string _speciality_college;
        private int? _speciality_years;
        /// <summary>
        /// 专业编号
        /// </summary>
        public string Speciality_ID
        {
            set { _speciality_id = value; }
            get { return _speciality_id; }
        }
        /// <summary>
        /// 专业名称
        /// </summary>
        public string Speciality_Name
        {
            set { _speciality_name = value; }
            get { return _speciality_name; }
        }
        /// <summary>
        /// 所属学院
        /// </summary>
        public string Speciality_College
        {
            set { _speciality_college = value; }
            get { return _speciality_college; }
        }
        /// <summary>
        /// 学制
        /// </summary>
        public int? Speciality_Years
        {
            set { _speciality_years = value; }
            get { return _speciality_years; }
        }
        #endregion Model

    }
}

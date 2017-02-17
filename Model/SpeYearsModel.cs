using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 学制表实体类SpeYears 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class SpeYearsModel
    {
        #region Model
        private int _speyears_id;
        private string _speyears_name;
        private int? _speyears_years;
        /// <summary>
        /// 学制编号
        /// </summary>
        public int SpeYears_ID
        {
            set { _speyears_id = value; }
            get { return _speyears_id; }
        }
        /// <summary>
        /// 学制名称
        /// </summary>
        public string SpeYears_Name
        {
            set { _speyears_name = value; }
            get { return _speyears_name; }
        }
        /// <summary>
        /// 学制时间
        /// </summary>
        public int? SpeYears_Years
        {
            set { _speyears_years = value; }
            get { return _speyears_years; }
        }
        #endregion Model
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 科目表 实体类Subjects 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class SubjectsModel
    {
        #region Model
        private int _subjects_id;
        private string _subjects_name;
        /// <summary>
        /// 科目编号
        /// </summary>
        public int Subjects_ID
        {
            set { _subjects_id = value; }
            get { return _subjects_id; }
        }
        /// <summary>
        /// 科目名称
        /// </summary>
        public string Subjects_Name
        {
            set { _subjects_name = value; }
            get { return _subjects_name; }
        }
        #endregion Model
    }
}

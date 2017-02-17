using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 专业科目关系表 实体类Sepc_Subjects 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Sepc_SubjectsModel
    {
        #region Model
        private string _sepc_id;
        private int _subjects_id;
        /// <summary>
        /// 专业编号
        /// </summary>
        public string Sepc_ID
        {
            set { _sepc_id = value; }
            get { return _sepc_id; }
        }
        /// <summary>
        /// 科目编号
        /// </summary>
        public int Subjects_ID
        {
            set { _subjects_id = value; }
            get { return _subjects_id; }
        }
        #endregion Model
    }
}

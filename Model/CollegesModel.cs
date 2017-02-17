using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 学院表实体类Colleges 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class CollegesModel
    {
        #region Model
        private string _college_id;
        private string _college_name;
        /// <summary>
        /// 学院编号
        /// </summary>
        public string College_ID
        {
            set { _college_id = value; }
            get { return _college_id; }
        }
        /// <summary>
        /// 学院名称
        /// </summary>
        public string College_Name
        {
            set { _college_name = value; }
            get { return _college_name; }
        }
        #endregion Model
    }
}

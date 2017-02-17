using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   /// <summary>
    /// 实体类ChangeTypes 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
     public class ChangeTypesModel
    {

        private int _changetypes_id;
        private string _changetypes_name;
        /// <summary>
        /// 学籍变动类型编号
        /// </summary>
        public int ChangeTypes_ID
        {
            set { _changetypes_id = value; }
            get { return _changetypes_id; }
        }
        /// <summary>
        /// 变动类型名称
        /// </summary>
        public string ChangeTypes_Name
        {
            set { _changetypes_name = value; }
            get { return _changetypes_name; }
        }
    }
}

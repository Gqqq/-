using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 学籍变动记录表 实体类ChangeTypesRecode 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class ChangeTypesRecodeModel
    {
        #region Model
        private int _changetypesrecode_id;
        private int? _changetypes_id;
        private string _changereason;
        private int? _changestudentid;
        private DateTime? _changedate;
        /// <summary>
        /// 记录编号
        /// </summary>
        public int ChangeTypesRecode_ID
        {
            set { _changetypesrecode_id = value; }
            get { return _changetypesrecode_id; }
        }
        /// <summary>
        /// 变动类型
        /// </summary>
        public int? ChangeTypes_ID
        {
            set { _changetypes_id = value; }
            get { return _changetypes_id; }
        }
        /// <summary>
        /// 变动原因
        /// </summary>
        public string ChangeReason
        {
            set { _changereason = value; }
            get { return _changereason; }
        }
        /// <summary>
        /// 变动学生编号
        /// </summary>
        public int? ChangeStudentID
        {
            set { _changestudentid = value; }
            get { return _changestudentid; }
        }
        /// <summary>
        /// 变动时间
        /// </summary>
        public DateTime? ChangeDate
        {
            set { _changedate = value; }
            get { return _changedate; }
        }
        #endregion Model

    }
}

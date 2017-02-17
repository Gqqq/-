using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 奖惩记录类别表实体类JiangFaTypes 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class JiangFaTypesModel
    {
        
        #region Model
        private int _jiangfatype_id;
        private string _jiangfatype_name;
        /// <summary>
        /// 奖惩记录类型编号
        /// </summary>
        public int PunishmentAwardTypes_ID
        {
            set { _jiangfatype_id = value; }
            get { return _jiangfatype_id; }
        }
        /// <summary>
        /// 奖惩记录类型名称
        /// </summary>
        public string PunishmentAwardTypes_Name
        {
            set { _jiangfatype_name = value; }
            get { return _jiangfatype_name; }
        }
        #endregion Model
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 奖惩记录表
    /// </summary>
    public class JiangFaModel
    {
        #region Model
        private int _jiangfa_id;
        private int? _jiangfatype_id;
        private int? _jiangfastudentid;
        private string _jiangfacontent;
        private string _jiangfareason;
        private DateTime? _jiangfadate;
        /// <summary>
        /// 奖惩记录编号
        /// </summary>
        public int PunishmentAwardsRecode_ID
        {
            set { _jiangfa_id = value; }
            get { return _jiangfa_id; }
        }
        /// <summary>
        /// 奖惩记录类别
        /// </summary>
        public int? PunishmentAwardsType_ID
        {
            set { _jiangfatype_id = value; }
            get { return _jiangfatype_id; }
        }
        /// <summary>
        /// 获奖学生编号
        /// </summary>
        public int? PunishmentAwardsStudentID
        {
            set { _jiangfastudentid = value; }
            get { return _jiangfastudentid; }
        }
        /// <summary>
        /// 获奖信息
        /// </summary>
        public string PunishmentAwardsContent
        {
            set { _jiangfacontent = value; }
            get { return _jiangfacontent; }
        }
        /// <summary>
        /// 获奖原因
        /// </summary>
        public string PunishmentAwardsReason
        {
            set { _jiangfareason = value; }
            get { return _jiangfareason; }
        }
        /// <summary>
        /// 获奖时间
        /// </summary>
        public DateTime? PunishmentAwardsDate
        {
            set { _jiangfadate = value; }
            get { return _jiangfadate; }
        }
        #endregion Model
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 管理员实体类AdminInfo 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class AdminInfoModel
    {
        #region Model
        private int _admin_id;
        private string _admin_name;
        private string _admin_password;
        private string _admin_level;
        /// <summary>
        /// 管理员编号
        /// </summary>
        public int Admin_ID
        {
            set { _admin_id = value; }
            get { return _admin_id; }
        }
        /// <summary>
        /// 管理员名
        /// </summary>
        public string Admin_Name
        {
            set { _admin_name = value; }
            get { return _admin_name; }
        }
        /// <summary>
        /// 管理员密码
        /// </summary>
        public string Admin_Password
        {
            set { _admin_password = value; }
            get { return _admin_password; }
        }
        /// <summary>
        /// 权限级别
        /// </summary>
        public string Admin_Level
        {
            set { _admin_level = value; }
            get { return _admin_level; }
        }
        #endregion Model

    }
}

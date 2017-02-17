using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 班主任表 实体类Teachers 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class TeachersModel
    {
        #region Model
        private int _teacher_id;
        private string _teacher_name;
        private string _teacher_tel;
        private string _teacher_sex;
        private DateTime? _teacher_indate;
        private DateTime? _teacher_birthday;
        private string _teacher_origin;
        /// <summary>
        /// 班主任编号
        /// </summary>
        public int Teacher_ID
        {
            set { _teacher_id = value; }
            get { return _teacher_id; }
        }
        /// <summary>
        /// 班主任姓名
        /// </summary>
        public string Teacher_Name
        {
            set { _teacher_name = value; }
            get { return _teacher_name; }
        }
        /// <summary>
        /// 班主任电话
        /// </summary>
        public string Teacher_Tel
        {
            set { _teacher_tel = value; }
            get { return _teacher_tel; }
        }
        /// <summary>
        /// 班主任性别
        /// </summary>
        public string Teacher_Sex
        {
            set { _teacher_sex = value; }
            get { return _teacher_sex; }
        }
        /// <summary>
        /// 班主任入职日期
        /// </summary>
        public DateTime? Teacher_InDate
        {
            set { _teacher_indate = value; }
            get { return _teacher_indate; }
        }
        /// <summary>
        /// 班主任出生日期
        /// </summary>
        public DateTime? Teacher_Birthday
        {
            set { _teacher_birthday = value; }
            get { return _teacher_birthday; }
        }
        /// <summary>
        /// 籍贯
        /// </summary>
        public string Teacher_Origin
        {
            set { _teacher_origin = value; }
            get { return _teacher_origin; }
        }
        #endregion Model
    }
}

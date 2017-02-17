using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 学生表 实体类Students 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class StudentsModel
    {
        #region Model
        private int _student_id;
        private string _student_name;
        private string _student_sex;
        private string _studentclass;
        private string _studentnum;
        private DateTime? _studententeryear;
        private string _studentorigin;
        private DateTime? _studentbirthday;
        private string _studentcard;
        private string _studentaddress;
        private string _familytel;
        private string _dormtel;
        private string _mobile;
        private string _email;
        /// <summary>
        /// 学生编号
        /// </summary>
        public int Student_ID
        {
            set { _student_id = value; }
            get { return _student_id; }
        }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Student_Name
        {
            set { _student_name = value; }
            get { return _student_name; }
        }
        /// <summary>
        /// 学生性别
        /// </summary>
        public string Student_Sex
        {
            set { _student_sex = value; }
            get { return _student_sex; }
        }
        /// <summary>
        /// 所属班级
        /// </summary>
        public string StudentClass
        {
            set { _studentclass = value; }
            get { return _studentclass; }
        }
        /// <summary>
        /// 学号
        /// </summary>
        public string StudentNum
        {
            set { _studentnum = value; }
            get { return _studentnum; }
        }
        /// <summary>
        /// 入学时间
        /// </summary>
        public DateTime? StudentEnterYear
        {
            set { _studententeryear = value; }
            get { return _studententeryear; }
        }
        /// <summary>
        /// 籍贯
        /// </summary>
        public string StudentOrigin
        {
            set { _studentorigin = value; }
            get { return _studentorigin; }
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? StudentBirthDay
        {
            set { _studentbirthday = value; }
            get { return _studentbirthday; }
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string StudentCard
        {
            set { _studentcard = value; }
            get { return _studentcard; }
        }
        /// <summary>
        /// 家庭住址
        /// </summary>
        public string StudentAddress
        {
            set { _studentaddress = value; }
            get { return _studentaddress; }
        }
        /// <summary>
        /// 家庭电话
        /// </summary>
        public string FamilyTel
        {
            set { _familytel = value; }
            get { return _familytel; }
        }
        public string DormTel
        {
            set { _dormtel = value; }
            get { return _dormtel; }
        }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        #endregion Model

    }
}

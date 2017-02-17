using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using DAL;
using System.Data.SqlClient;

namespace BLL
{
   public class AdminInfoBLL
    {
       AdminInfoDAL admin = new AdminInfoDAL();
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="model"></param>

        public void AddAdminInfo(AdminInfoModel model)
        {
            admin.AddAdminInfo(model);
        }
        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="model"></param>

        public void DelAdminInfo(AdminInfoModel model)
        {
            admin.DelAdminInfo(model);
        }
        /// <summary>
        /// 获取所有管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetAllAdminInfo(AdminInfoModel model)
        {
           return admin.GetAllAdminInfo(model);
        }
        /// <summary>
        /// 修改管理员
        /// </summary>
        /// <param name="model"></param>
        public void UpdateAdminInfo(AdminInfoModel model)
        {
            admin.UpdateAdminInfo(model);
        }
       /// <summary>
       /// 检查旧密码
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        public bool CheckOldPass(AdminInfoModel model)
        {
            return admin.CheckOldPass(model);
        }
       /// <summary>
       /// 检查管理员权限
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        public bool CheckAdminInfo(AdminInfoModel model)
        {
            return admin.CheckAdminInfo(model);
        }
       /// <summary>
       /// 管理员登陆
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        public SqlDataReader AdminLogin(AdminInfoModel model)
        {
            return admin.AdminLogin(model);
        }
    }
}

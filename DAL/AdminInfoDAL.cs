using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public class AdminInfoDAL
    {
       /// <summary>
       /// 添加管理员
       /// </summary>
       /// <param name="model"></param>

       public void AddAdminInfo(AdminInfoModel model)
       {
           string sql = "insert into AdminInfo values(@0,@1,@2)";
           SqlHelper.ExNonQuery(sql,"添加管理员", model.Admin_Name,model.Admin_Password,model.Admin_Level);
       }
       /// <summary>
       /// 删除管理员
       /// </summary>
       /// <param name="model"></param>

       public void DelAdminInfo(AdminInfoModel model)
       {
           string sql = "delete AdminInfo where Admin_ID=@0";
           SqlHelper.ExNonQuery(sql,"删除管理员", model.Admin_ID);
       }
       /// <summary>
       /// 获取所有管理员
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public DataTable GetAllAdminInfo(AdminInfoModel model)
       {
           string sql = "select Admin_ID 管理员编号,Admin_Name 管理员名称,Admin_Level 管理员权限 from AdminInfo";
           return SqlHelper.GetDataTable(sql);
       }
       /// <summary>
       /// 修改管理员密码
       /// </summary>
       /// <param name="model"></param>
       public void UpdateAdminInfo(AdminInfoModel model)
       {
           string sql = "update AdminInfo set Admin_Password=@0 where Admin_ID=@1";
           SqlHelper.ExNonQuery(sql,"修改密码", model.Admin_Password,model.Admin_ID);
       }
       /// <summary>
       /// 检查旧密码
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>

       public bool CheckOldPass(AdminInfoModel model)
       {
           string sql = "select * from AdminInfo where Admin_ID=@0 and Admin_Password=@1";
           SqlDataReader dr = SqlHelper.ExReader(sql,model.Admin_ID,model.Admin_Password);
           bool bo = dr.Read();
           dr.Close();
           return bo;

       }
       /// <summary>
       /// 检查管理员权限
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>

       public bool CheckAdminInfo(AdminInfoModel model)
       {
           string sql = "select * from AdminInfo where Admin_Name=@0";
           SqlDataReader dr = SqlHelper.ExReader(sql, model.Admin_Name);
           bool b = dr.Read();
           dr.Close();
           return b;
       }
       /// <summary>
       /// 管理员登陆
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>

       public SqlDataReader AdminLogin(AdminInfoModel model)
       {
           string sql = "select * from AdminInfo where Admin_Name=@0 and Admin_Password=@1";
           SqlDataReader dr=SqlHelper.ExReader(sql,model.Admin_Name,model.Admin_Password);
           return dr;
       }
   
    }
}

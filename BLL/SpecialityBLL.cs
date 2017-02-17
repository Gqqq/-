using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;
using System.Windows.Forms;

namespace BLL
{
    //添加专业信息的业务类
     public class SpecialityBLL
     {
         #region 添加专业信息的业务方法
         /// <summary>
         /// 添加专业信息的业务方法
         /// </summary>
         /// <param name="model">专业的实体对象</param>
         public void AddSpeciality(SpecialityModel model)
         {
             SpecialityDAL Speciality = new SpecialityDAL();
             Speciality.AddSpeciality(model);
         }
         #endregion

         #region 删除专业信息的业务方法
         /// <summary>
         /// 删除专业信息的业务方法
         /// </summary>
         /// <param name="model">专业的实体对象</param>
         public void DeleSpeciality(SpecialityModel model)
         {
             SpecialityDAL Speciality = new SpecialityDAL();
             Speciality.DeleSpeciality(model);
         }
         #endregion

         #region 修改专业信息的业务访问方法
         /// <summary>
         /// 修改专业信息的业务访问方法
         /// </summary>
         /// <param name="model">专业的实体对象</param>
         public void UPSpeciality(SpecialityModel model)
         {
             SpecialityDAL Speciality = new SpecialityDAL();
             Speciality.UPSpeciality(model);
         }
         #endregion

         #region 查询所有专业信息的
         /// <summary>
         /// 查询所有专业信息的
         /// </summary>
         /// <returns>DataTable数据表</returns>
         public DataTable GetAllSpeciality()
         {
             SpecialityDAL Speciality = new SpecialityDAL();
             DataTable dt = Speciality.GetAllSpeciality();
             return dt;
         }
         #endregion

         #region 检测专业编号
         /// <summary>
         /// 检测专业编号
         /// </summary>
         /// <param name="model">专业的实体对象</param>
         public bool SeleSpeciality(SpecialityModel model)
         {
             SpecialityDAL Speciality = new SpecialityDAL();
             bool b = Speciality.SeleSpeciality(model);
             return b;
             
         }
         #endregion

         #region 根据专业编号查询
         /// <summary>
         /// 根据专业编号查询
         /// </summary>
         /// <param name="model">专业的实体对象</param>
         /// <returns>DataTable数据表</returns>
         public DataTable GetIdSpeciality(SpecialityModel model)
         {
             SpecialityDAL Speciality = new SpecialityDAL();
             DataTable dt = Speciality.GetIdSpeciality(model);
             return dt;
         }
         #endregion

         #region 根据专业名称查询
         /// <summary>
         /// 根据专业名称查询
         /// </summary>
         /// <param name="model">专业的实体对象</param>
         /// <returns>DataTable数据表</returns>
         public DataTable GetNameSpeciality(SpecialityModel model)
         {
             SpecialityDAL Speciality = new SpecialityDAL();
             DataTable dt = Speciality.GetNameSpeciality(model);
             return dt;
         }
         #endregion
     }
}

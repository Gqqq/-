using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Model;
using DAL;

namespace BLL
{
    //业务类
    public class ChangeTypesBLL
    {
        #region 添加学籍异动类型业务
        /// <summary>
        /// 添加学籍异动类型业务
        /// </summary>
        /// <param name="model">学籍异动类型的实体对象</param>
        public void AddChangeTypes(ChangeTypesModel model)
        {
            ChangeTypesDAL change = new ChangeTypesDAL();
            change.AddChangeTypes(model);
        }
        #endregion

        #region 查询所有学籍异动类型业务
        /// <summary>
        /// 查询所有学籍异动类型业务
        /// </summary>
        /// <returns>数据表</returns>
        public DataTable GetAllChangeTypes()
        {
            ChangeTypesDAL change = new ChangeTypesDAL();
            DataTable dt = change.GetAllChangeTypes();
            return dt;
        }
        #endregion

        #region 删除学籍异动类型业务
        /// <summary>
        /// 删除学籍异动类型业务
        /// </summary>
        /// <param name="model">学籍异动类型的实体对象</param>
        public void DeleChangeTypes(ChangeTypesModel model)
        {
            ChangeTypesDAL change = new ChangeTypesDAL();
            change.DeteChangeTypes(model);
        }
        #endregion
    }
}

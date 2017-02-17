using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    //业务层
    public class SpeYearsBLL
    {
        #region 添加学制业务
        /// <summary>
        /// 添加学制业务
        /// </summary>
        /// <param name="model">学制的实体对象</param>
        public void AddSpeYears(SpeYearsModel model)
        {
            SpeYearsDAL SpeYear = new SpeYearsDAL();
            SpeYear.AddSpeYears(model);
        }
        #endregion

        #region 删除学制业务
        /// <summary>
        /// 删除学制业务
        /// </summary>
        /// <param name="model">学制的实体对象</param>
        public void DeleSpeYears(SpeYearsModel model)
        {
            SpeYearsDAL SpeYear = new SpeYearsDAL();
            SpeYear.DeleSpeYears(model);
        }
        #endregion

        #region 查询所有学制业务
        /// <summary>
        /// 查询所有学制业务
        /// </summary>
        /// <returns>DataTable数据表</returns>
        public DataTable GetAllSpeYears()
        {
            SpeYearsDAL SpeYear = new SpeYearsDAL();
            DataTable dt = SpeYear.GetAllSpeYears();
            return dt;
        }
        #endregion
        public DataTable GetSpeyearbySpeciality(SpecialityModel model)
        {
            SpeYearsDAL SpeYear = new SpeYearsDAL();
            DataTable dt = SpeYear.GetSpeyearbySpeciality(model);
            return dt;
        }
    }
}

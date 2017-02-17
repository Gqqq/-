using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace BLL
{
   public class JiangFaRecodeBLL
    {
       JiangFaRecodeDAL jiangfa = new JiangFaRecodeDAL();
       /// <summary>
       /// 添加奖罚记录业务方法
       /// </summary>
       /// <param name="model"></param>
       public void AddJingFa(JiangFaModel model)
       {
           jiangfa.AddJingFa(model);
       }
       /// <summary>
       /// 删除奖罚记录业务方法
       /// </summary>
       /// <param name="model"></param>
       public void DelJiangFa(JiangFaModel model)
       {
           jiangfa.DelJiangFa(model);
       }
       /// <summary>
       /// 查询指定学生奖励记录
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public DataTable GetJiangRecodeByStudent(JiangFaModel model)
       {
           return jiangfa.GetJiangRecodeByStudent(model);
       }
       /// <summary>
       /// 查询指定学生惩罚记录
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public DataTable GetFaRecodeByStudent(JiangFaModel model)
       {
           return jiangfa.GetFaRecodeByStudent(model);
       }
    }
}

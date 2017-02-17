using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using Model;

namespace BLL
{
   public class ChangeRecodeBLL
    {
       ChangeRecodeDAL change = new ChangeRecodeDAL();
       public DataTable GetChangeRecodeByStudent(ChangeTypesRecodeModel model)
       {
           return change.GetChangeRecodeByStudent(model);
       }
       public void AddChangeRecode(ChangeTypesRecodeModel model)
       {
           change.AddChangeRecode(model);
       }
       public DataTable GetAllChangeTypeRecode(ChangeTypesRecodeModel model)
       {
           return change.GetAllChangeTypeRecode(model);
       }
       public void DelAllChangeRecode(ChangeTypesRecodeModel model)
       {
           change.DelAllChangeRecode(model);

       }
    }
}

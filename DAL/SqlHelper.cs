using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAL
{
    
    /// <summary>
    /// 静态类封装SQL数据库通用方法
    /// 要求每个成员都是静态的
    /// </summary>
   public static class SqlHelper
    {
        #region  创建连接对象并使用静态构造函数初始化对象
        static string str = "Data Source=.;Initial Catalog=StuSystem;Integrated Security=True";
         static SqlConnection con;
         static SqlHelper()
         {
             con = new SqlConnection(str);
         }
    #endregion

        #region 创建打开和关闭对象
         /// <summary>
         /// 打开连接方法
         /// </summary>
         static void Open()
         {
             if (con.State == ConnectionState.Closed)
                 con.Open();
         }
         /// <summary>
         /// 关闭连接方法
         /// </summary>
         static void Close()
         {
             if (con.State == ConnectionState.Open)
             {
                 con.Close();
             }
         }
         #endregion

        #region 对数据库进行增加，修改，删除时使用该方法
         /// <summary>
         /// 对数据库进行增加，修改，删除时使用该方法
        /// </summary>
         /// <param name="sql">命令文本</param>
         /// <param name="mess">...操作成功，...操作失败</param>
         /// <param name="pa">命令文本中所需要的参数</param>
         public static void ExNonQuery(string sql, string mess, params object[] pa)
         {
             int k;
             using (SqlCommand cmd = con.CreateCommand())
             {
                 cmd.CommandText = sql;
                 if (pa.Length > 0 && pa != null)
                 {
                     for (int i = 0; i < pa.Length; i++)
                     {
                         SqlParameter sp = new SqlParameter("@" + i, pa[i]);
                         cmd.Parameters.Add(sp);
                     }
                 }

                 Open();

                 k = cmd.ExecuteNonQuery();
                 Close();



             }
             if (k > 0)
             {
                 MessageBox.Show(mess + "成功");
             }
             else
             {
                 MessageBox.Show(mess + "失败");
             }
         }
         #endregion

        #region 对数据库进行聚合查询，并返回第一行第一列的值
        /// <summary>
        /// 对数据库进行聚合查询，并返回第一行第一列的值
        /// </summary>
         /// <param name="sql">命令文本</param>
         /// <param name="pa">命令文本中所需要的参数</param>
         /// <returns>第一行第一列的值</returns>
         public static object ExScalar(string sql, params object[] pa)
         {
             object o;
             using (SqlCommand cmd=con.CreateCommand())
             {
                 cmd.CommandText = sql;
                 if (pa.Length > 0 && pa != null)
                 {
                     for (int i = 0; i < pa.Length; i++)
                     {
                         SqlParameter sp = new SqlParameter("@" + i, pa[i]);
                         cmd.Parameters.Add(sp);
                     }
                 }
                 Open();
                 o = cmd.ExecuteScalar();
                 Close();
             }
             return o;
         }
        #endregion

        #region 对数据库进行只读查询
         /// <summary>
         /// 对数据库进行只读查询
         /// </summary>
         /// <param name="sql">命令文本</param>
         /// <param name="pa">命令文本所需参数</param>
         /// <returns>SqlDataReader</returns>
         public static SqlDataReader ExReader(string sql, params object[] pa)
         {
             SqlDataReader dr;
             using (SqlCommand cmd=con.CreateCommand())
             {
                 cmd.CommandText = sql;
                 if (pa.Length > 0 && pa != null)
                 {
                     for (int i = 0; i < pa.Length; i++)
                     {
                         SqlParameter sp = new SqlParameter("@"+i,pa[i]);
                         cmd.Parameters.Add(sp);
                     }
                 }
                 Open();
                 dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
             }
             return dr;
         }
        #endregion

        #region 对数据库进行查询，并返回一个DataTable的数据集
        /// <summary>
         /// 对数据库进行查询，并返回一个DataTable的数据集
        /// </summary>
         /// <param name="sql">命令文本</param>
         /// <param name="pa">命令文本中所需要的参数</param>
         /// <returns>DataTable可修改的数据集</returns>
         public static DataTable GetDataTable(string sql,params object[] pa)
         {
             DataTable dt = new DataTable();
             using (SqlCommand cmd=con.CreateCommand())
             {
                 cmd.CommandText = sql;
                 if (pa.Length > 0 && pa != null)
                 {
                     for (int i = 0; i < pa.Length; i++)
                     {
                         SqlParameter sp = new SqlParameter("@"+i,pa[i]);
                         cmd.Parameters.Add(sp);
                     }
                 }
                 using (SqlDataAdapter da=new SqlDataAdapter(cmd))
                 {
                     Open();
                     da.Fill(dt); 
                 }
             }
             return dt;
         }
        #endregion
         /// <summary>
         /// 对数据库进行增加，修改，删除时使用该方法
         /// </summary>
         /// <param name="sql">命令文本</param>
         /// <param name="mess">...操作成功，...操作失败</param>
         /// <param name="pa">命令文本中所需要的参数</param>
         public static int ExNonQuery(string sql, params object[] pa)
         {
             int k=0;
             //using语句块创建的对象，可以自动销毁
             //con.CreateCommand()表示在连接对象下创建执行对象
             using (SqlCommand cmd = con.CreateCommand())
             {
                 cmd.CommandText = sql;
                 if (pa.Length > 0 && pa != null)
                 {
                     for (int i = 0; i < pa.Length; i++)
                     {
                         SqlParameter sp = new SqlParameter("@" + i, pa[i]);//构建SQL语句中的参数
                         cmd.Parameters.Add(sp);
                     }
                 }

                 Open();

                 k = cmd.ExecuteNonQuery();
                 Close();
             }
             return k;
         }
         #region 回滚事务
         /// <summary>
        /// 事务执行插入，删除，修改时，用事务处理，确保数据完整性和一致性的通用方法
        /// </summary>
        /// <param name="r">命令数量</param>
        /// <param name="sqllist">命令列表</param>
        /// <returns>受影响的行数</returns>
         public static int BeginTranExecNoneQuery( List<string> sqllist)
         {
             int result = 0, count = 0;
             using (SqlCommand cmd = con.CreateCommand())
             {
                 Open();//调用打开连接方法
                 cmd.Transaction = con.BeginTransaction("添加成绩");//开始事务处理

                 try
                 {
                     foreach (string sql in sqllist)
                     {
                         cmd.CommandText = sql;//要执行的SQL命令文本
                         result = cmd.ExecuteNonQuery();//执行SQL命令，返回受影响的行数
                         if (result <= 0)
                         {
                             cmd.Transaction.Rollback("添加成绩");//回滚事务
                         }
                         count++;
                     }
                     cmd.Transaction.Commit();//提交事务
                 }
                 catch
                 {
                     result = 0;
                     cmd.Transaction.Rollback();
                 }
                 finally
                 {
                     Close();//调用关闭连接的方法
                 }
             }
             return count;
         }
#endregion
    }
}

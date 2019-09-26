using Log4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   public class DBHelper
    {
        private static string conStr = @"Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";

        /// <summary>
        /// 获取一张表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetTable(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    if (ps != null)
                    {
                        sda.SelectCommand.Parameters.AddRange(ps);
                    }
                    DataTable dt = new DataTable();
                    try
                    {
                        sda.Fill(dt);

                    }
                    catch (Exception e)
                    {
                        WriterLog(e);
                    }
                    return dt;
                }
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static DataTable FenYeTable(string sql, params SqlParameter[] ps)
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (ps != null)
            {
                sda.SelectCommand.Parameters.AddRange(ps);
            }
            DataTable table = new DataTable();
            try
            {
                sda.Fill(table);
            }
            catch (Exception e)
            {
                WriterLog(e);
            }

            return table;
        }
        /// <summary>
        /// 写入错误的文件
        /// </summary>
        /// <param name="e"></param>
        public static void WriterLog(Exception ex)
        {
            LogHelper.WriteLog(typeof(DBHelper), ex.Message);
        }

        /// <summary>
        /// 通用的增删改查
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        /// 

        public static int ExcuteNonQuery(string sql, params SqlParameter[] ps)
        {
            int num = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    try
                    {
                        con.Open();
                        num = cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {

                        WriterLog(e);
                    }
                    return num;
                }
            }
        }

        /// <summary>
        /// 读取单行单列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object ExcuteScalar(string sql, params SqlParameter[] ps)
        {
            object obj = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    try
                    {
                        con.Open();
                        obj = cmd.ExecuteScalar();

                    }
                    catch (Exception e)
                    {

                        WriterLog(e);
                    }
                    return obj;
                }
            }

        }

        /// <summary>
        /// 读取一行
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] ps)
        {
            SqlDataReader result = null;
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sql, con);
            if (ps != null)
            {
                cmd.Parameters.AddRange(ps);
            }
            try
            {
                con.Open();
                result = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception e)
            {
                WriterLog(e);
            }
            return result;
        }
    }
}

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyBBSWebApi
{
    public class SqlHelper
    {
        public string ConStr { get; } = "Server=localhost;Database=MyBBS;Trusted_Connection=True;";

        private SqlConnection connection;

        /// <summary>
        /// 执行sql语句并返回DataTable
        /// </summary>
        /// <param name="sqlStr">sql查询字符串</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public DataTable ExecuteToTable(string sqlStr, params SqlParameter[] parameters)
        {
            using(connection = new SqlConnection(ConStr))
            {
                using(SqlCommand cmd = new SqlCommand(sqlStr, connection))
                {
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    sda.Fill(table);
                    return table;
                }
            }
        }

        /// <summary>
        /// 执行sql语句并返回其所影响的行数
        /// </summary>
        /// <param name="sqlStr">sql查询字符串</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sqlStr, params SqlParameter[] parameters)
        {
            using(connection = new SqlConnection(ConStr))
            {
                using(SqlCommand cmd = new SqlCommand(sqlStr, connection))
                {
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 执行sql语句并返回第一行第一列的值
        /// </summary>
        /// <param name="sqlStr">sql查询字符串</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public object ExecuteScalar(string sqlStr, params SqlParameter[] parameters)
        {
            using(connection = new SqlConnection(ConStr))
            {
                using(SqlCommand cmd = new SqlCommand(sqlStr, connection))
                {
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}

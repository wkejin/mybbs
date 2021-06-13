using Microsoft.Data.SqlClient;
using MyBBSWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyBBSWebApi.Services
{
    public static class UserService
    {
        /// <summary>
        /// 检查用户登录信息，返回true则验证通过，返回false则验证不通过。
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static bool CheckLogin(string userName, string password)
        {
            string sql = "select count(*) from Users where UserName=@UserName and UserPwd=@UserPwd";
            SqlParameter[] parameters =
            {
                new SqlParameter("UserName", userName),
                new SqlParameter("UserPwd", password)
            };
            int res = (int)SqlHelper.ExecuteScalar(sql, parameters);
            if(res == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查用户名，如果返回true，说明用户名不存在，返回false，说明用户名已存在。
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public static bool CheckUserName(string userName)
        {
            string sql = "select count(*) from Users where UserName=@UserName";
            SqlParameter parameter = new SqlParameter("UserName", userName);
            int res = (int)SqlHelper.ExecuteScalar(sql, parameter);
            if(res > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 根据Id获取一个用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User GetUser(int id)
        {
            string sql = "select * from Users where Id=@Id";
            SqlParameter parameter = new SqlParameter("@Id", id);
            DataTable table = SqlHelper.ExecuteToTable(sql, parameter);
            return ToModel(table.Rows[0]);
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public static List<User> GetUsers()
        {
            DataTable table = SqlHelper.ExecuteToTable("select * from Users");
            List<User> users = new List<User>();
            foreach (DataRow row in table.Rows)
            {
                users.Add(ToModel(row));
            }
            return users;
        }

        /// <summary>
        /// 创建一个用户，返回true表示创建成功
        /// </summary>
        /// <param name="user">用户实例</param>
        /// <returns></returns>
        public static bool CreateUser(User user)
        {
            string sql = "insert into Users(UserNO,UserName,UserPwd,UserLevel) values(@UserNo,@UserName,@UserPwd,@UserLevel)";
            SqlParameter[] parameters =
            {
                new SqlParameter("UserNO", user.UserNO),
                new SqlParameter("UserName", user.UserName),
                new SqlParameter("UserPwd", user.UserPwd),
                new SqlParameter("UserLevel", user.UserLevel)
            };
            int res = SqlHelper.ExecuteNonQuery(sql, parameters);
            if(res <= 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 将DataTable中的行转换为用户实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private static User ToModel(DataRow row)
        {
            User user = new User()
            {
                Id = Convert.ToInt32(row["Id"]),
                UserNO = row["UserNO"].ToString(),
                UserName = row["UserName"].ToString(),
                UserPwd = row["UserPwd"].ToString(),
                UserLevel = Convert.ToInt32(row["UserLevel"])
            };
            return user;
        }
    }
}

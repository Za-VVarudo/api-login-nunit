using System;
using System.IO;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using BookAPI.Models.UserModels;

namespace BookAPI.Models
{
    public class UserManagement
    {
         private readonly string _dbConString = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                               .AddJsonFile("appsettings.json", true, true)
                                                               .Build()["ConnectionString:DbConString"];
        public UserManagement() { }
        public UserManagement(string constring) { 
            _dbConString = constring; 
        }
        public User Login(string username, string password)
        {
            User user = null;
            if (username == null || password == null) throw new ArgumentException("Username and Password must be in [2,50] characters !");
            else 
                if (username.Length > 50 || username.Length < 2 || password.Length > 50 || password.Length < 2) throw new ArgumentException("Username and Password must be in [2,50] characters !");
            
            using (var con = new SqlConnection(_dbConString)) 
            {
                if (con != null)
                {
                    string queryText = " SELECT userID, fullName, email, phone, address, roleID " +
                        " FROM tblUser " +
                        " WHERE userID = @id AND password = @pass ";
                    user = con.Query<User>(queryText, new { id = username, pass = password }).FirstOrDefault();
                }
            }
            return user;
        }

    }
}

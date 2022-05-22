using System;
using System.Globalization;
using MySqlConnector;

namespace BlueProject.Models
{
    public class UserModel
    {
        // public string User_seq { get; set; }
        public string  User_name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string ConvertPassword()
        {
            var sha = new System.Security.Cryptography.HMACSHA512();
            sha.Key = System.Text.Encoding.UTF8.GetBytes(this.Password.Length.ToString());
            var hash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(this.Password));

            return this.Password = System.Convert.ToBase64String(hash);
        }

        internal int Register()
        {
            string sql = @"
                  INSERT INTO myweb.t_user(
                                     user_name,
                                     email,
                                     password                                     
                  )  
                values (@user_name, @email, @password)";
            using (var conn = new MySqlConnection("Server=127.0.0.1;Database=myweb;Uid=root;Pwd=dookie91Sql!;"))
            {
                conn.Open();
                return Dapper.SqlMapper.Execute(conn, sql, this);
            }
        }

        internal UserModel GetLoginUser()
        {
            string sql = @"
                            SELECT 
                            user_name,   
                            email,
                            password
                            FROM myweb.t_user
                            WHERE user_name = @user_name
                                                        ";
            UserModel user;
            using (var conn = new MySqlConnection("Server=127.0.0.1;Database=myweb;Uid=root;Pwd=dookie91Sql!;"))
            {
                conn.Open();
                user = Dapper.SqlMapper.QuerySingleOrDefault<UserModel>(conn, sql, this);
            }

            if (user == null)
            {
                throw new Exception("User does not exist");
            }

            if (user.Password != this.Password)
            {
                throw new Exception("Password is wrong");
            }
            return user;
        }
    }
}
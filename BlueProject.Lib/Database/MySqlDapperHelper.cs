using System.Collections.Generic;
using System.Linq;
using MySqlConnector;

namespace BlueProject.Lib.Database
{
    public class MySqlDapperHelper
    {
        private MySqlConnection _conn;
        public MySqlDapperHelper()
        {
            _conn = new MySqlConnection("Server=127.0.0.1;Database=myweb;Uid=root;Pwd=dookie91Sql!;");
        }

        public List<T> Query<T>(string sql, object param)
        {
            return Dapper.SqlMapper.Query<T>(_conn, sql, param).ToList();
        }
        
        
        public int Execute<T>(string sql, object param)
        {
            return Dapper.SqlMapper.Execute(_conn, sql, param);
        }
        

            
            
    

    }

   
}  
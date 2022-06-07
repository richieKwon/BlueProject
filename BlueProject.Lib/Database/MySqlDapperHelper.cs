using System.Collections.Generic;
using System.Linq;
using MySqlConnector;

namespace BlueProject.Lib.Database
{
    public class MySqlDapperHelper
    {
        private MySqlConnection _connection;
        private MySqlTransaction _transaction;
        public MySqlDapperHelper()
        {
            _connection = new MySqlConnection("Server=127.0.0.1;Database=myweb;Uid=root;Pwd=dookie91Sql!;");
        }

        public List<T> Query<T>(string sql, object param)
        {
            return Dapper.SqlMapper.Query<T>(_connection, sql, param).ToList();
        }
         
        
        public int Execute(string sql, object param)
        {
            return Dapper.SqlMapper.Execute(_connection, sql, param);
        }
        

            
            
    

    }

   
}  
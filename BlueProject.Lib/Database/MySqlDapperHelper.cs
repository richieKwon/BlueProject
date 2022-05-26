using System.Collections.Generic;
using MySqlConnector;

namespace BlueProject.Lib.Database
{
    public class MySqlDapperHelper
    {
        private MySqlConnection _conn;
        public MySqlDapperHelper()
        {
            _conn = conn = new MySqlConnection("Server=127.0.0.1;Database=myweb;Uid=root;Pwd=dookie91Sql!;");
        }

        public List<T> GetQuery<T>(string sql, object praram)
        { 
        }
        using (var conn = new MySqlConnection("Server=127.0.0.1;Database=myweb;Uid=root;Pwd=dookie91Sql!;"))
        {
            
        }

            
            
    

    }

   
}  
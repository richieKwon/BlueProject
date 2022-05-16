using System.Collections.Generic;
using System.Linq;
using MySqlConnector;

namespace BlueProject.Models
{
    public class TicketModel
    {
        public int Ticket_id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }

        public static List<TicketModel> GetList(string status)
        {
            using (var conn = new MySqlConnection("Server=127.0.0.1;Database=myweb;Uid=root;Pwd=dookie91Sql!;"))
            {
                conn.Open();

                string sql = @"
                 select ticket_id,
                 title,
                 status
                 from myweb.t_ticket A
                 where status = @status            
                ";
                return Dapper.SqlMapper.Query<TicketModel>(conn, sql, new { status = status }).ToList();
                //
            }
        }
    }
}
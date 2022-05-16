using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlueProject.Models;
using MySqlConnector;

namespace BlueProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PrivacyChange(int ticket_id, string title)
        {
            using (var conn = new MySqlConnection("Server=127.0.0.1;Database=myweb;Uid=root;Pwd=dookie91Sql!;"))
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"  
                            update t_ticket
                            set title = @title
                            where ticket_id = @ticket_id
                        ";
                    cmd.Parameters.AddWithValue("@ticket_id", ticket_id);
                    cmd.Parameters.AddWithValue("@title", title);

                    // var reader = cmd.ExecuteReader(); // return data reader
                    cmd.ExecuteNonQuery(); // return total number of 
                   
                }
            }

            return Redirect("/home/Privacy");
            // return Json( new {msg = "OK"});
        }

        public IActionResult Privacy()
        {
            
            string status = "In Progress";

            return View(TicketModel.GetList(status));
            // var dt = new DataTable(); // create an instance for a datatable

//             using (var conn = new MySqlConnection("Server=127.0.0.1;Database=myweb;Uid=root;Pwd=dookie91Sql!;"))
//             {
//                 conn.Open();
//                 string status = "In Progress";
//
//                 string sql = @"
//                 select ticket_id,
//                 title,
//                 status
//                 from myweb.t_ticket A
//                 where status = @status   
// ";

            // ViewData["ticketList"]=Dapper.SqlMapper.Query<TicketModel>(conn, sql, new { status = status }).ToList();


            // using (var cmd = new MySqlCommand())
            // {
            //     string status = "In Progress";
            //     cmd.Connection = conn;
            //     cmd.CommandText = @"
            //             select ticket_id,
            //             title,
            //             status
            //             from myweb.t_ticket A
            //         ";
            //     cmd.Parameters.AddWithValue("status", status);
            //
            //     var reader = cmd.ExecuteReader(); // return data reader
            //     // cmd.ExecuteNonQuery(); // return total number of 
            //     dt.Load(reader);
            //     ViewData["dt"] = dt;
            // }
            //     return View(Dapper.SqlMapper.Query<TicketModel>(conn, sql, new { status = status }).ToList());
            // }

            // var list = new List<TicketModel>();



        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Test(List<int> x, string y)
        {
            return View();
        }

        public IActionResult Test2()
        {
            var model = new TestModel();
            model.X = 7;
            model.Y = "Yera";
            return Json(model);
            // return (new {X =7, Y="Yera"}) 
            // return File("filePath", "applicaiton/octet-stream/", "filename") 
        }

        public IActionResult Test3(string x, string y)
        {
            ViewBag.x = x;
            ViewBag.y = y;
            List<TestModel> list = new List<TestModel>();
            list.Add(new TestModel() { X = 1, Y = "A" });
            list.Add(new TestModel() { X = 2, Y = "A" });
            list.Add(new TestModel() { X = 3, Y = "C" });
            list.Add(new TestModel() { X = 7, Y = "K" });
            ViewBag.list = list;
            return View(list);
        }
    }
}
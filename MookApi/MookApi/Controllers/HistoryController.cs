using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MookApi.Context;
using MookApi.Models;
using System.Data;
using System.Data.Entity;
using System.Reflection;

namespace MookApi.Controllers
{
    public class HistoryController : ControllerBase
    {

        private  AppDbContext _context;

        public HistoryController(AppDbContext context)
        {
            context = _context;
        }

        [HttpGet]
        [Route("index")]
        public ActionResult<History> get()
        {

            string cn = "server = WSP001PTEMP\\ILECY; Database = MookDB; User ID = sa; Password = 123456$ilecy; ";

            List<History> history = new List<History>();

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(c => c.Name == "History");

            var dbSet = _context.GetType().GetMember("DbSet");

            return Ok();
        }
        public enum DbSetName
        {
            Admin,
            Book,
            BookToBuy,
            Comment,
            History
        }
    }
}

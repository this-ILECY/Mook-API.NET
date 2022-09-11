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
    public static class MyExtensions
    {
        public static IQueryable<object> Set(this AppDbContext _context, Type t)
        {
            return (IQueryable<object>)_context.GetType().GetMethod("Set").MakeGenericMethod(t).Invoke(_context, null);
        }
    }

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

            var db = MyExtensions.Set(_context, type);

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

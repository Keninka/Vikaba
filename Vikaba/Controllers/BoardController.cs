using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vikaba.Data;

namespace Vikaba.Controllers
{
    public class BoardController : Controller
    {
        private readonly ApplicationDbContext _db;

        // GET
        public BoardController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var categories = _db.Categories
                .Include(category => category.Boards)
                .ToArray();

            return View(categories);
        }
    }
}
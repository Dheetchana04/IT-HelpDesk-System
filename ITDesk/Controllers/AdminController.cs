using ITDesk.Data;
using ITDesk.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITDesk.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            ViewBag.Total = _context.Tickets.Count();
            ViewBag.Open = _context.Tickets.Count(t => t.Status == "Open");
            ViewBag.Resolved = _context.Tickets.Count(t => t.Status == "Resolved");

            return View();
        }
    }
}

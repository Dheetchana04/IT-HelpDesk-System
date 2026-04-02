using ITDesk.Data;
using ITDesk.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITDesk.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AssetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Assets.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Asset asset)
        {
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }


}

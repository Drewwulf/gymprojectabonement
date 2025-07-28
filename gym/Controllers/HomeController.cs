using System.Diagnostics;
using gym.Models;
using gym.Data;             // ????? ??? using
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  // ??? async ???????

namespace gym.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;  // ????? ????

        // ????? AppDbContext ? ???????????
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // ????? ????? async ? ?????????? ?????????
        public async Task<IActionResult> Index()
        {
            var students = await _context.Students.ToListAsync();
            return View(students);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

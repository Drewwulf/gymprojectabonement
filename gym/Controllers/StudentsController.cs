using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gym.Models;
using gym.Data;

namespace gym.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.Students.ToListAsync();
            return View(students);
        }
    }

}

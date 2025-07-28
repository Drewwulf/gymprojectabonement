using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using gym.Models;
using gym.ViewModels;
using gym.Data;
using System;
using System.Threading.Tasks;

namespace gym.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is invalid");
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.PhoneNumber,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                Console.WriteLine("User creation failed:");
                foreach (var error in result.Errors)
                    Console.WriteLine(error.Description);

                return View(model);
            }

            Console.WriteLine($"User created with ID: {user.Id}");

            var student = new Student
            {
                FullName = model.FullName,
                Phone = model.PhoneNumber,
                Email = model.Email,
                BirthDate = model.BirthDate
            };

            _context.Students.Add(student);

            try
            {
                var changes = await _context.SaveChangesAsync();
                Console.WriteLine($"Changes saved to DB: {changes}");
                Console.WriteLine($"Student created with ID: {student.Id}");

                ViewBag.SuccessMessage = "Реєстрація пройшла успішно!";
                ModelState.Clear();
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during saving student:");
                Console.WriteLine(ex.ToString());

                ModelState.AddModelError("", "Помилка при додаванні студента: " + ex.Message);
                return View(model);
            }
        }
    }
}

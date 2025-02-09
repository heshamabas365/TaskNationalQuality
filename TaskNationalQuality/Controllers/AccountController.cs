using Microsoft.AspNetCore.Mvc;
using TaskNationalQuality.Data;
using TaskNationalQuality.Models;
using TaskNationalQuality.ViewModels.User;

namespace TaskNationalQuality.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existingUser = _context.Users.FirstOrDefault(u => u.Username == model.Username);
                    if (existingUser == null)
                    {
                        var user = new User
                        {
                            Username = model.Username,
                            CustomerName = model.CustomerName,
                            Date = DateTime.Now,
                            Password = model.Password
                        };


                        _context.Users.Add(user);
                        user.Code = user.Id.ToString() + "1000";

                        _context.SaveChanges();


                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        ModelState.AddModelError("", "User with this username already exists.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occurred: {ex.Message}");

                    ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                }
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("UserId", user.Id);

                    Console.WriteLine("User ID stored in session: " + HttpContext.Session.GetInt32("UserId"));

                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }
            return View(model);
        }




        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

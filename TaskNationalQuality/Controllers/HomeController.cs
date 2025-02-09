using Microsoft.AspNetCore.Mvc;
using TaskNationalQuality.Data;

namespace TaskNationalQuality.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;

        }
        public IActionResult Dashboard()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == userId.Value);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.userinfo = user;

            var products = _context.Products.Where(Z => Z.UserId == user.Id).ToList();


            return View(products);
        }



    }



}


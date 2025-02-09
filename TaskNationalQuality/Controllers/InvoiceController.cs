using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskNationalQuality.Data;
using TaskNationalQuality.Models;

namespace TaskNationalQuality.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult SelectProducts()
        {
            var products = _context.Products.ToList();
            ViewBag.ProductsList = new SelectList(products, "Id", "Name");
            return View(new List<Product>());
        }

        [HttpPost]
        public IActionResult SelectProducts(int selectedProductId)
        {
            var selectedProducts = new List<Product>();

            if (selectedProductId != 0)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == selectedProductId);
                if (product != null)
                {
                    selectedProducts.Add(product);
                }
            }

            var products = _context.Products.ToList();
            ViewBag.ProductsList = new SelectList(products, "Id", "Name");
            return View(selectedProducts);
        }
    }
}

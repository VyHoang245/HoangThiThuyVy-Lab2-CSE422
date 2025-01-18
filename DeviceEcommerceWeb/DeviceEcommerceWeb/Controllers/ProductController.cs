using DeviceEcommerceWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeviceEcommerceWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductManagementContext _context;
        public ProductController(ProductManagementContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListProduct()
        {
            var products = _context.Product.ToList();
            //List<Product> products = new List<Product>
            //{
            //     new Product (1, "Iphone 12",  100, "SmartPhone", "In Use" ),
            //     new Product (2, "Iphone 13",  200, "SmartPhone", "In Use" ),
            //     new Product (3, "Iphone 14",  150, "SmartPhone", "In Use" )
            //};
            ViewBag.Products = products;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Name, string Category, string Status, int Quantity)
        {
            var maxId = _context.Product.Max(c => (int?)c.Id) ?? 0;
            var newId = maxId + 1;
            var product = new Product
            (newId, Name, Quantity, Category, Status);
            _context.Product.Add(product);
            _context.SaveChanges();
            return RedirectToAction("ListProduct", "Product");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Product.FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int id, string Name, string Category, string Status, int Quantity)
        {
            var product = _context.Product.FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = Name;
            product.Category = Category;
            product.Status = Status;
            product.Quantity = Quantity;
            _context.SaveChanges();
            return RedirectToAction("ListProduct", "Product");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = _context.Product.FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("ListProduct", "Product");
        }
    }
}

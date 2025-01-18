using DeviceEcommerceWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeviceEcommerceWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProductManagementContext _context;
        public CategoryController(ProductManagementContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Category.ToList();
            //List<Category> categories = new List<Category> {
                
            //    new Category(1, "SmartPhone", "Convinience to use"),
            //    new Category(2, "Laptop", "Convinience to use"),
            //    new Category(3, "Smart Watch", "Convinience to use"),
            //    new Category(4, "Keyboard", "Convinience to use")
            //};
            ViewBag.Categories = categories;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Name, string Description)
        {
            var maxId = _context.Category.Max(c => (int?)c.Id) ?? 0;
            var newId = maxId + 1;
            var category = new Category
            (newId,Name,Description);
            _context.Category.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.Category.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(int id, string name, string description)
        {
            var category = _context.Category.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            category.Name = name;
            category.Description = description;
            _context.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _context.Category.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
         
            _context.Category.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
    }
}

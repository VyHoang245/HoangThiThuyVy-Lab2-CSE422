using DeviceEcommerceWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DeviceEcommerceWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly ProductManagementContext _context;

        public UserController(ProductManagementContext context)
        {
            _context = context;
        }
        //private List<User> Users = new List<User>
        //        {
        //             new User(1, "Iphone 12",  "SmartPhone", "In Use" ),
        //             new User(2, "Iphone 13", "SmartPhone", "In Use" ),
        //             new User(3, "Iphone 14", "SmartPhone", "In Use" )
        //        };

    public IActionResult Index()
        {
            var users = _context.User.ToList();
            ViewBag.Users = users;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.User.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _context.User.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                //Users.ForEach(
                //    u => { if (u.Id == user.Id) { Users.Remove(u); } });
                //Users.Add(user);

                _context.User.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = _context.User.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            _context.User.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

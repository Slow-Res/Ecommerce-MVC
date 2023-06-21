using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db { get; set; }
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var list = _db.Categories.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            TempData["sucess"] = "A Category has been created";
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
          

            if (id == null || id == 0)
            {
                return NotFound();
            }


            Category? obj = _db.Categories.Find(id);
      
            if (obj == null)
            {
                return NotFound();
            }
 
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _db.Categories.Update(category);
            _db.SaveChanges();
            TempData["sucess"] = "A Category has been Updated";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }


            Category? obj = _db.Categories.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Remove(obj);
            _db.SaveChanges();
            TempData["sucess"] = "A Category has been Deleted";
            return RedirectToAction("index");
        }

    }
}

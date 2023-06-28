
using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using DataAcess.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Ecommerce.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var list = _unitOfWork.Category.GetAll().ToList();
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


            TempData["success"] = "A Category has been created";
            _unitOfWork.Category.Add(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {


            if (id == null || id == 0)
            {
                return NotFound();
            }


            Category? obj = _unitOfWork.Category.Get(x => x.Id == id);


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
            _unitOfWork.Category.Update(category);
            _unitOfWork.Save();
            TempData["success"] = "A Category has been Updated";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }


            Category? obj = _unitOfWork.Category.Get(x => x.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "A Category has been Deleted";
            return RedirectToAction("index");
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using movieSeller.DataAccess.Data;
using movieSeller.DataAccess.Repository.IRepository;
using movieSeller.Models.Models;


namespace movieSellerWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        public CategoryController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> categoryList = _UnitOfWork.Category.GetAll().ToList();
            return View(categoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "name and order  should not be exactly  same");
            }
            if (obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value");
            }
            if (ModelState.IsValid)
            {
                _UnitOfWork.Category.Add(obj);
                _UnitOfWork.save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryfromDB = _UnitOfWork.Category.GetFirstorDefault(u => u.Id == id);
            //   Category ? categoryfromDB = _context.Categories.FirstOrDefault(u=>u.Id == id);
            if (categoryfromDB == null)
            {
                return NotFound();
            }
            return View(categoryfromDB);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "name and order  should not be exactly  same");
            }
            if (obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value");
            }
            if (ModelState.IsValid)
            {
                _UnitOfWork.Category.Update(obj);
                _UnitOfWork.save();
                TempData["success"] = "Category Updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryfromDB = _UnitOfWork.Category.GetFirstorDefault(u => u.Id == id);
            //   Category ? categoryfromDB = _context.Categories.FirstOrDefault(u=>u.Id == id);
            if (categoryfromDB == null)
            {
                return NotFound();
            }
            return View(categoryfromDB);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _UnitOfWork.Category.GetFirstorDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _UnitOfWork.Category.Remove(obj);
            _UnitOfWork.save();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");

        }

    }
}

using Microsoft.AspNetCore.Mvc;
using movieSeller.DataAccess.Repository;
using movieSeller.DataAccess.Repository.IRepository;
using movieSeller.Models.Models;

namespace movieSellerWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        public ProductController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> ProductList = _UnitOfWork.Product.GetAll().ToList();
            return View(ProductList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
       
            if (ModelState.IsValid)
            {
                _UnitOfWork.Product.Add(obj);
                _UnitOfWork.save();
                TempData["success"] = "Product created successfully";
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

            Product? ProductfromDB = _UnitOfWork.Product.GetFirstorDefault(u => u.Id == id);
            //   Category ? categoryfromDB = _context.Categories.FirstOrDefault(u=>u.Id == id);
            if (ProductfromDB == null)
            {
                return NotFound();
            }
            return View(ProductfromDB);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.Product.Update(obj);
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

           Product? ProductfromDB = _UnitOfWork.Product.GetFirstorDefault(u => u.Id == id);
            //   Category ? categoryfromDB = _context.Categories.FirstOrDefault(u=>u.Id == id);
            if (ProductfromDB == null)
            {
                return NotFound();
            }
            return View(ProductfromDB);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? obj = _UnitOfWork.Product.GetFirstorDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _UnitOfWork.Product.Remove(obj);
            _UnitOfWork.save();
            TempData["success"] = "Product Deleted successfully";
            return RedirectToAction("Index");

        }

    }
}

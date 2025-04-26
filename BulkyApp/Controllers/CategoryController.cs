using BulkyApp.Data;
using BulkyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }


        //public IActionResult InsertIntoDB(Category obj)
        //{
        //    _db.Categories.Add(obj);
        //    _db.SaveChanges();
        //    //return View("Index");
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name cannot be exactly same as Display Order");
            }

            if (obj.Name!= null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is not a valid category name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                //return View("Index");
                return RedirectToAction("Index");
            }
            return View();
            
        }

        //[HttpPost]
        //public IActionResult InsertIntoDB(Category obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Categories.Add(obj);
        //        _db.SaveChanges();
        //        //return View("Index");
        //        return RedirectToAction("Index");
        //    }
        //    return View();

        //}
    }
}

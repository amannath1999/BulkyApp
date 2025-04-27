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
                TempData["success"] = "Category created successfully!";
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

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            //Category? category = _db.Categories.FirstOrDefault(c => c.Id == id);
            Category? category1 = _db.Categories.Find(id);
            //Category? category2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();

            if(category1 == null)
            {
                return NotFound();
            }
            return View(category1);
        }


        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                //return View("Index");
                TempData["success"] = "Category updated successfully!";
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

            //Category? category = _db.Categories.FirstOrDefault(c => c.Id == id);
            Category? category1 = _db.Categories.Find(id);
            //Category? category2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();

            if (category1 == null)
            {
                return NotFound();
            }
            return View(category1);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category1 = _db.Categories.Find(id);

            if (category1 == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(category1);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
           
        }
    }
}

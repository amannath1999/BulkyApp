using BulkyWebApp_Razor.Data;
using BulkyWebApp_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebApp_Razor.Pages.Categories
{
    public class EditModel : PageModel
    {
        public readonly ApplicationDBContext _db;

        
        public EditModel(ApplicationDBContext db)
        {_db = db; }

        [BindProperty]
        public Category Category { get; set; }
        public void OnGet(int? id)
        {
            Category = _db.Categories.Find(id);

        }

        //public IActionResult OnPost(Category category)
        //{
        //    _db.Categories.Update(category);
        //    _db.SaveChanges();
        //    return Redirect("/categories/index");
        //}

        public IActionResult OnPost()
        {
            _db.Categories.Update(Category);
            _db.SaveChanges();
            TempData["success"] = "Category updated successfully!";
            return Redirect("/categories/index");
        }
    }
}

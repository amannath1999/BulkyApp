using BulkyWebApp_Razor.Data;
using BulkyWebApp_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebApp_Razor.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        public readonly ApplicationDBContext _db;

        [BindProperty]
        public Category Category { get; set; }
        public DeleteModel(ApplicationDBContext db)
        {
            _db= db;
        }
        public void OnGet(int? id)
        {
            Category = _db.Categories.Find(id);
        }

        public IActionResult OnPost()
        {
            Category obj = _db.Categories.Find(Category.Id);
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully!";
            return Redirect("/categories/index");
        }
    }
}

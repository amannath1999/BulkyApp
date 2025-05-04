using BulkyWebApp_Razor.Data;
using BulkyWebApp_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebApp_Razor.Pages.Categories
{
    public class CreateModel : PageModel
    {
        public readonly ApplicationDBContext _db;


        //we add bind-property to make sure that whatever we enter in the UI (since the form is post)
        //we will be able to access here from cshtml page otherwise u will see all null values
        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully!";
            return Redirect("/categories/index");
        }
    }
}

using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db; // I think the underscore before db is because is read only?

        public CategoryController(ApplicationDbContext db) // Added this so i can use dependency injection
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList); // This way i pass the object to the view so i can show it in html
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }
    }
}

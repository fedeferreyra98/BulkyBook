﻿using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

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

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //This help to prevent cross site request forgery, more on that on dotnetmastery.com/Home/Vlog
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString()) /*Adding custom error messages*/
            {
                //if we change the "CustomError" Key to "Name" the error displays below the Name textbox in the View
                ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match the Name"); 
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges(); //This pushes the changes to the database
                return RedirectToAction("Index"); //This way we redirect the user to Category Index
            }
            return View(obj);
        }
    }
}

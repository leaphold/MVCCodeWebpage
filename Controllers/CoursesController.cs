using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace uppgift1
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CoursesController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            List<Course> objCoursesList = _db.Courses.ToList();

            return View(objCoursesList);
        }

        public IActionResult Create()
        {
            return View();
        }
        //TODO: Add validation to the Create action method --- Validation almost becomes like a Constructor for the Create action method
        [HttpPost]// SERVER SIDE VALIDATION
        public IActionResult Create(Course obj)
        {
            if (obj.Title.ToLower() == "test")
            {
                ModelState.AddModelError("Title", "This title is not allowed");
            }
            if (obj.StartDate <= DateTime.Now)
            {
                ModelState.AddModelError("StartDate", "Start Date must be greater than today");
            }

            if (obj.StartDate >= obj.EndDate)
            {
                ModelState.AddModelError("EndDate", "End Date must be greater than Start Date");
            }

            if (ModelState.IsValid)
            {
                _db.Courses.Add(obj);
                _db.SaveChanges();
                TempData["success"]="Course created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //This is the Get action method - retreive the selected data by its ID from the database
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Course? courseFromDb = _db.Courses.Find(id);

            if (courseFromDb == null)
            {
                return NotFound();
            }

            return View(courseFromDb);
        }

        //this is the POst action method
        [HttpPost]
        public IActionResult Edit(Course obj)
        {

          
            if (ModelState.IsValid)
            {
                _db.Courses.Update(obj);
                _db.SaveChanges();//here is will go to the database and create that category
                TempData["success"]="Course edited successfully";

                return RedirectToAction("Index");
            }
            return View();
        }

    //This is the GET action method for Delete
  public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Course? courseFromDb = _db.Courses.Find(id);

            if (courseFromDb == null)
            {
                return NotFound();
            }

            return View(courseFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id) 
        {
            Course? obj=_db.Courses.Find(id);
          

            if (obj == null)
            {
                return NotFound();
            }

            _db.Courses.Remove(obj);
            _db.SaveChanges();
            TempData["success"]="Course deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
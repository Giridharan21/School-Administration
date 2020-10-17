using SchoolAdministration.Logic;
using SchoolAdministration.Logic.Models;
using SchoolAdministration.Web_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolAdministration.Web_UI.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        // GET: Courses
        private SchoolDbAccess context;
        public CoursesController()
        {
            context = new SchoolDbAccess();
        }
        public async Task<ActionResult> Index()
        {
            var list = new List<CourseDetailsViewModel>();
            if (ModelState.IsValid)
            {
                var courses = await context.GetAllCoursesAsync();

                foreach (var i in courses)
                {
                    list.Add(new CourseDetailsViewModel
                    {
                        Id = i.Id,
                        Date = i.Date,
                        Description = i.Description,
                        FilledToCapacity = i.FilledToCapacity,
                        Name = i.Name,
                        NumOfParticipants = i.NumberOfParticipants,
                        Teacher = i.Teacher
                    });
                }
            }
            return View(list);
        }
        [HttpGet]
        public async Task<ActionResult> Index(string search)
        {
            var list = new List<CourseDetailsViewModel>();
            if (ModelState.IsValid)
            {
                var courses = await context.GetAllCoursesAsync(search);

                foreach (var i in courses)
                {
                    list.Add(new CourseDetailsViewModel
                    {
                        Id = i.Id,
                        Date = i.Date,
                        Description = i.Description,
                        FilledToCapacity = i.FilledToCapacity,
                        Name = i.Name,
                        NumOfParticipants = i.NumberOfParticipants,
                        Teacher = i.Teacher
                    });
                }
            }
            return View(list);
            
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                await context.CreateCourseAsync(new Logic.Models.CourseModel(model.Name, model.Description, model.Date, model.Teacher));
                return RedirectToAction("Index");
            }
            
            return View();
        }

        public async Task<ActionResult> Edit(int Id)
        {
            var course = await context.GetCourseAsync(Id);
            var model = new CourseViewModel()
            {
                Date = course.Date,
                Teacher = course.Teacher,
                Description = course.Description,
                Name = course.Name,
                Id = Id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                await context.UpdateCourseAsync(new CourseModel(model.Id, model.Name, model.Description, model.Date, model.Teacher,model.FilledToCapacity));
                return RedirectToAction("index");
            }

            return View();
        }

        public async Task<ActionResult> Delete(int id)
        {
            await context.DeleteCourseAsync(id);
            return RedirectToAction("index");
        }
    }
}
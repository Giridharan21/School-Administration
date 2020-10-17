using SchoolAdministration.Logic;
using SchoolAdministration.Logic.Models;
using SchoolAdministration.Web_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SchoolAdministration.Web_UI.Controllers
{
    public class HomeController : Controller
    {
        private SchoolDbAccess context;
        public HomeController()
        {

            context = new SchoolDbAccess();
        }
        public async Task<ActionResult> Enroll(int id)
        {
            if (ModelState.IsValid)
            {
                var course = await context.GetCourseAsync(id);
                if (course == null)
                {
                    return PartialView("Error");
                }
                var enroll = new EnrollViewModel() { CourseId = id, CourseName = course.Name };
                return View(enroll);
            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Enroll(EnrollViewModel model)
        {
            if (ModelState.IsValid)
            {

                await context.EnrollStudent(new EnrollModel() { 
                    CourseId= model.CourseId,
                    Name = model.Name,
                    Surname = model.Surname,
                    Address = model.Address,
                    Telephone = model.Telephone,
                    Email= model.Email
                });
                return RedirectToAction("index");
            }
            return View(model);
        }
        public async Task<ActionResult> Index()
        {
            var list = new List<CourseViewModel>();
            if (ModelState.IsValid)
            {
                var courses = await context.GetAllCoursesAsync();

                foreach (var i in courses)
                {
                    list.Add(new CourseViewModel
                    {
                        Id = i.Id,
                        Date = i.Date,
                        Description = i.Description,
                        Name = i.Name,
                        Teacher = i.Teacher
                    });
                }
            }
            return View(list);
            
        }

        
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var id = await context.AuthenticateAsync(new LoginModel(model.Username, model.Password));
                if (id !=0)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, model.Remember);
                    return RedirectToAction("Index","Courses");
                }
                
            }

            ViewBag.result = "Invalid Credentials!.";
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
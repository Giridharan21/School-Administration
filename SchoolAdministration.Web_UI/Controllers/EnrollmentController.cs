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
    public class EnrollmentController : Controller
    {
        // GET: Enrollment
        private SchoolDbAccess context;
        public EnrollmentController()
        {
            context = new SchoolDbAccess();
        }
        public async Task<ActionResult> Index()
        {
            var enrollments = await context.GetAllEnrollmentsAsync();
            var list = new List<EnrollmentDetailsViewModel>();
            foreach (var i in enrollments)
            {
                list.Add(new EnrollmentDetailsViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Telephone = i.Telephone,
                    Surname = i.Surname,
                    Email = i.Email,
                    CourseName = i.CourseName,
                    Address = i.Address,
                    Date = i.Date,
                    Status = i.Status
                });
            }
            
            return View(list);
        }
        [HttpPost]
        public async Task<ActionResult> Index(string search)
        {
            var enrollments = await context.GetAllEnrollmentsAsync(search);
            var list = new List<EnrollmentDetailsViewModel>();
            foreach (var i in enrollments)
            {
                list.Add(new EnrollmentDetailsViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Telephone = i.Telephone,
                    Surname = i.Surname,
                    Email = i.Email,
                    CourseName = i.CourseName,
                    Address = i.Address,
                    Date = i.Date,
                    Status = i.Status
                });
            }

            return Json(list,JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Edit(int Id)
        {
            if (ModelState.IsValid)
            {
                var i = await context.GetEnrollmentAsync(Id);
                if (i is null)
                    return PartialView("Error");
                var model = new EnrollmentDetailsViewModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Telephone = i.Telephone,
                    Surname = i.Surname,
                    Email = i.Email,
                    CourseName = i.CourseName,
                    Address = i.Address,
                    Date = i.Date,
                    Status = i.Status
                };
                return View(model);
            }
            
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EnrollmentDetailsViewModel i)
        {
            await context.updateEnrollmentAsync(new EnrollmentDetailsModel
            {
                Id = i.Id,
                Name = i.Name,
                Telephone = i.Telephone,
                Surname = i.Surname,
                Email = i.Email,
                Address = i.Address,
                Date = i.Date,
                Status = i.Status
            });
            return RedirectToAction("index");
        }
    }
}
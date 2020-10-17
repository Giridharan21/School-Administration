using SchoolAdministration.Data;
using SchoolAdministration.Data.Tables;
using SchoolAdministration.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdministration.Logic
{
    public class SchoolDbAccess
    {
        private SchoolDb context = new SchoolDb();
        public async Task<int> AuthenticateAsync(LoginModel model)
        {
            var y = context.Users.Count();
            if(y == 0)
            {
                context.Users.Add(new Data.Tables.Admins { Password = model.Password, UserName = model.Username });
                await context.SaveChangesAsync();
            }
            var x = await Task.Run(()=> context.Users.Where(i => i.UserName == model.Username && i.Password == model.Password).Select(i=>i.Id).FirstOrDefault());
            
            
            
            return x;
        }

        public async Task<List<EnrollmentDetailsModel>> GetAllEnrollmentsAsync()
        {
            var list = new List<EnrollmentDetailsModel>();
            await Task.Run(() =>
            {
                foreach (var i in context.Enrollments.Include("Course"))
                {
                    list.Add(new EnrollmentDetailsModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Telephone = i.Telephone,
                        Surname = i.Surname,
                        Email = i.Email,
                        CourseName = i.Course.Name,
                        Address = i.Address,
                        Date = i.Date,
                        Status = (Models.Status)i.Status
                    });
                }
            });
            return list;
        }

        public async Task<List<EnrollmentDetailsModel>> GetAllEnrollmentsAsync(string search)
        {
            var list = await GetAllEnrollmentsAsync();
            if (list == null)
                return null;
            else if (string.IsNullOrWhiteSpace(search))
                return list;
            return list.Where(i => 
                i.Name.ToLower().Contains(search.ToLower()) ||
                i.Email.ToLower().Contains(search.ToLower()) ||
                i.Address.ToLower().Contains(search.ToLower()) ||
                i.CourseName.ToLower().Contains(search.ToLower())
                
            ).ToList();
        }

        public async Task<List<CourseDetailsModel>> GetAllCoursesAsync(string search)
        {
            var list = await GetAllCoursesAsync();
            if (list == null)
                return null;
            else if (string.IsNullOrWhiteSpace(search))
                return list;
            return list.Where(i =>i.Name.ToLower().Contains(search.ToLower())).ToList();
        }

        public async Task<EnrollmentDetailsModel> GetEnrollmentAsync(int id)
        {
            var i = await Task.Run(()=> context.Enrollments.Include("Course").Where(j => j.Id == id).FirstOrDefault());
            if (i == null)
                return null;

            var enroll = new EnrollmentDetailsModel()
            {
                Id = i.Id,
                Name = i.Name,
                Telephone = i.Telephone,
                Surname = i.Surname,
                Email = i.Email,
                CourseName = i.Course.Name,
                Address = i.Address,
                Date = i.Date,
                Status = (Models.Status)i.Status
            };
            return enroll;

        }

        public async Task updateEnrollmentAsync(EnrollmentDetailsModel i)
        {
            var enroll = await Task.Run(() => context.Enrollments.Include("Course").Where(j => j.Id == i.Id).FirstOrDefault());
            if (enroll != null)
            {
                enroll.Id = i.Id;
                enroll.Name = i.Name;
                enroll.Telephone = i.Telephone;
                enroll.Surname = i.Surname;
                enroll.Email = i.Email;
                enroll.Address = i.Address;
                enroll.Date = i.Date;
                enroll.Status =(Data.Tables.Status) i.Status;
            }
            await context.SaveChangesAsync();
        }

        public async Task<bool> EnrollStudent(EnrollModel model)
        {
            var check = await AddEnrollCountToCourse(model.CourseId);
            if (!check)
                return false;
            var enroll = new Enrollments
            {
                CourseId = model.CourseId,
                Name = model.Name,
                Surname = model.Surname,
                Address = model.Address,
                Telephone = model.Telephone,
                Email = model.Email,
                Date= DateTime.Now
            };
            
            context.Enrollments.Add(enroll);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AddEnrollCountToCourse(int id)
        {
            var course = await Task.Run(() => context.Courses.Where(i => i.Id == id).FirstOrDefault());
            if (course == null)
                return false;
            course.NumberOfParticipants += 1;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CourseDetailsModel>> GetAllCoursesAsync()
        {
            var courses =await Task.Run(()=> context.Courses.ToList());
            var list = new List<CourseDetailsModel>();

            foreach (var i in courses)
            {
                list.Add(new CourseDetailsModel
                {
                    Id = i.Id,
                    Date = i.Date,
                    Description = i.Description,
                    FilledToCapacity = i.FilledToCapacity,
                    Name = i.Name,
                    NumberOfParticipants = i.NumberOfParticipants,
                    Teacher = i.Teacher
                });
            }

            return list;
        }

        public async Task<bool> CreateCourseAsync(CourseModel model)
        {
            var course = new Courses
            {
                Name= model.Name,
                Date=model.Date,
                Description = model.Description,
                Teacher = model.Teacher,
            };

            try
            {
                context.Courses.Add(course);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<CourseModel> GetCourseAsync(int id)
        {
            var course = await Task.Run(()=> context.Courses.Where(i => i.Id == id).FirstOrDefault());
            if (course == null)
                return null;
            var model = new CourseModel(course.Name,course.Description,course.Date,course.Teacher);
            return model;
        }

        public async Task UpdateCourseAsync(CourseModel courseModel)
        {
            var course = await Task.Run(() => context.Courses.Where(i => i.Id == courseModel.Id).FirstOrDefault());

            if(course != null)
            {
                course.Name = courseModel.Name;
                course.Teacher = courseModel.Teacher;
                course.Description = courseModel.Description;
                course.Date = courseModel.Date;
                course.FilledToCapacity = courseModel.FilledToCapacity;
                await context.SaveChangesAsync();
            }
            
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await Task.Run(() => context.Courses.Where(i => i.Id == id).FirstOrDefault());
            if (course != null)
            {
                context.Courses.Remove(course);
                await context.SaveChangesAsync();
            }
            
        }
    }
}

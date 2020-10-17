using SchoolAdministration.Logic.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolAdministration.Web_UI.ViewModels
{
    public class EnrollmentDetailsViewModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }
        [Required]
        public Status Status { get; set; }

    }
}
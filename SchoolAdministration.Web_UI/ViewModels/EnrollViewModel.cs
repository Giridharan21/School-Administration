using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolAdministration.Web_UI.ViewModels
{
    public class EnrollViewModel
    {
        [Required]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(40)]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(20)]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Telephone { get; set; }
    }
}
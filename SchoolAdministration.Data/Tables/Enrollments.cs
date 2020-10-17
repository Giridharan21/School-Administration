using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAdministration.Data.Tables
{
    public class Enrollments
    {
        public int Id { get; set; }
        public Courses Course { get; set; }
        
        [ForeignKey("Course")]
        [Required]
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Telephone { get; set; }
        public Status Status { get; set; }
        public DateTime Date { get; set; }

    }
}

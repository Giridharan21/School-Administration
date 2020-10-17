using SchoolAdministration.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdministration.Logic.Models
{
    public class EnrollmentDetailsModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
    }
}

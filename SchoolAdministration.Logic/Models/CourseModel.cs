using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdministration.Logic.Models
{
    public class CourseModel
    {
        public CourseModel(string name, string description, DateTime date, string teacher)
        {
            Name = name;
            Description = description;
            Date = date;
            Teacher = teacher;
        }
        public CourseModel()
        {

        }
        

        public CourseModel(int id, string name, string description, DateTime date, string teacher, bool filledToCapacity)
        {
            Id = id;
            Name = name;
            Description = description;
            Date = date;
            Teacher = teacher;
            FilledToCapacity = filledToCapacity;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Teacher { get; set; }
        public bool FilledToCapacity { get; }
    }
}

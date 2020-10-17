using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdministration.Logic.Models
{
    public class CourseDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool FilledToCapacity { get; set; }
        public int NumberOfParticipants { get; set; }
        public string Teacher { get; set; }

    }
}

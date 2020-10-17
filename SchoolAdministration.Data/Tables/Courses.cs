using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdministration.Data.Tables
{
    public class Courses
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [DefaultValue(false)]
        public bool FilledToCapacity { get; set; }
        [DefaultValue(0)]
        public int NumberOfParticipants { get; set; }
        public string Teacher { get; set; }

    }
}

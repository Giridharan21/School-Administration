using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolAdministration.Web_UI.ViewModels
{
    public class CourseViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(100,MinimumLength =10)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        public string Teacher { get; set; }
        [DisplayName("Filled to Capacity")]
        public bool FilledToCapacity { get; set; }
        public int Id { get; set; }
    }
}
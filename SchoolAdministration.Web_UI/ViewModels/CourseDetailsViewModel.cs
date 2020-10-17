using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolAdministration.Web_UI.ViewModels
{
    public class CourseDetailsViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool FilledToCapacity { get; set; }
        public int NumOfParticipants { get; set; }
        public string Teacher { get; set; }
    }
}
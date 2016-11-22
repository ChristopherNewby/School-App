using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class coursesModel
    {
        [DisplayName("Student Name")]
        public List <Student> newStudent { get; set; }

        [DisplayName("Course Name")]
        public Cours newCourse { get; set; }
    }
}
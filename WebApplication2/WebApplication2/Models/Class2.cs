using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Class2
    {
        [DisplayName("Student Name")]
        public Student newStudent { get; set; }

        [DisplayName("Course Name")]
        public List<Cours> newCourse { get; set; }

        //[DisplayName("Course Name")]
        //public Cours newCourse { get; set; }

        //[DisplayName("Student Courses")]
        //public StudentsCours newStudCourse { get; set; }
    }
}
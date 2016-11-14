using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2
{

    [MetadataType(typeof(CoursMetaData))]
    public partial class Cours
    {

    }
    public partial class CoursMetaData
    {
        [DisplayName("Course Id")]

        public int CourseId { get; set; }
        [DisplayName("Course Name")]
        [Required(ErrorMessage = "You must enter a course name!")]
        [MaxLength(50, ErrorMessage = "Course name must be 50 character or less.")]
        public string CourseName { get; set; }
        [DisplayName("Course Description")]
        [Required(ErrorMessage = "You must enter a course description!")]
        [MaxLength(50, ErrorMessage = "Description must be 50 character or less.")]
        public string CourseDescription { get; set; }
    }

    [MetadataType(typeof(StudentMetaData))]
    public partial class Student
    {
    }
    public partial class StudentMetaData
    {
        [DisplayName("Student Id")]

        public int StudentId { get; set; }

        [DisplayName("Student Name")]
        [Required(ErrorMessage = "You must enter a student name!")]
        [MaxLength(50, ErrorMessage = "Student name must be 50 character or less.")]
        public string StudentName { get; set; }
    }



}

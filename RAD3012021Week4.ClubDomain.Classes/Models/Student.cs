﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD3012021Week4.ClubDomain.Classes.Models
{
    public class Student
    {
        [Key]
        [Display(Name = "Student ID")]
        public string StudentID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Second Name")]
        public int? CourseID { get; set; }
        public string SecondName { get; set; }
        [ForeignKey("CourseID")]
        public virtual Course MyCourse { get; set; }
    }
}

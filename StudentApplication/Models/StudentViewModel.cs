using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using StudentApplication.Helpers;
using System.Web.Mvc;

namespace StudentApplication.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Required]
        public String FullName { get; set; }

        [Range(6,20)]
        public int Age { get; set; }

        [GradeRange("A,B,C,D,F",ErrorMessage="not a valid grade")]
        public String Grade { get; set; }

        public Gender Gender { get; set; }

        [Remote("ValidateSchool","Student", ErrorMessage="Invalid school")]
        public String School { get; set; }
    }
}
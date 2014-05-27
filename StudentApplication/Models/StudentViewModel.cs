using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using StudentApplication.Helpers;

namespace StudentApplication.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Range(6,20)]
        public int Age { get; set; }

        [GradeRange("A,B,C,D,F",ErrorMessage="not a valid grade")]
        public String Grade { get; set; }

        public Gender Gender { get; set; }
    }
}
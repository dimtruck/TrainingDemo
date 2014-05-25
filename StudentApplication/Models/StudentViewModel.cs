using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;

namespace StudentApplication.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }
    }
}
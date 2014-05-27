using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApplication.Helpers
{
    public class DateOfBirthResolver : ValueResolver<Student, int>
    {
        protected override int ResolveCore(Student source)
        {
            //won't work in all examples but this is a simple use case :)
            return DateTime.Today.Year - source.DateOfBirth.Year;
        }
    }
}
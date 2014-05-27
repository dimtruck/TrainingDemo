using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApplication.Helpers
{
    public class FullNameResolver : ValueResolver<Student, string>
    {
        protected override string ResolveCore(Student source)
        {
            return source.FirstName + " " + source.LastName;
        }
    }
}
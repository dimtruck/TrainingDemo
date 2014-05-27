using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentApplication.Helpers
{
    public class GradeRangeAttribute : ValidationAttribute
    {
        private readonly IEnumerable<String> _range;

        public GradeRangeAttribute(String range) : base("{0} is out of range")
        {
            _range = range != null ? range.Split(',').AsEnumerable<String>() : new List<String>();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                if (_range == null || !_range.Contains(valueAsString))
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace EBoxOffice.Domain.Validation
{
    public class DateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d >= DateTime.Now;
        }
    }
}

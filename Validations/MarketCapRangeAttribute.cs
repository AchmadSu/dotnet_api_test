using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Validations
{
    public class MarketCapRangeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is long val)
            {
                if (val < 1L || val > 5_000_000_000L)
                {
                    return new ValidationResult("MarketCap must be between 1 and 5,000,000,000.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
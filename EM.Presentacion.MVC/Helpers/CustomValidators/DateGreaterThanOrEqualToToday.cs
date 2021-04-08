using System;
using System.ComponentModel.DataAnnotations;

namespace EM.Presentacion.MVC.Helpers.CustomValidators
{
    public class DateGreaterThanOrEqualToToday : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return $"El campo {name} debe ser una fecha en el futuro.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dateValue = value as DateTime? ?? new DateTime();

            if (dateValue.Date < DateTime.Today.Date)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}

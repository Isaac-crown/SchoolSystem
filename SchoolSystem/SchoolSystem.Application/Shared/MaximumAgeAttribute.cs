using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Application.Shared
{


    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class MaximumAgeAttribute : ValidationAttribute
    {
        private readonly int _maxAge;

        public MaximumAgeAttribute(int maxAge)
        {
            _maxAge = maxAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateOfBirth)
            {
                var age = DateTime.Now.Year - dateOfBirth.Year;

                if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                    age--;

                if (age > _maxAge)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }


}

using System.ComponentModel.DataAnnotations;

namespace SEP3_Tier1.Validation
{
    public class PhoneValidation : ValidationAttribute
    {
        public string GetErrorMessage() => "Phone number is too long, please enter a shorter one";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            int toCheck = (int)value;

            if (toCheck.ToString().Length > 15) {
                return new ValidationResult(GetErrorMessage());
            }
            
            return ValidationResult.Success;
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace SEP3_Tier1.Validation
{
    public class DoubleValidation : ValidationAttribute
    {

        public string GetErrorMessage() => "Price is too large, please enter a smaller one";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            double toCheck = (double)value;

            if (toCheck.ToString().Length > 10) {
                return new ValidationResult(GetErrorMessage());
            }
            
            return ValidationResult.Success;
        }
    }
}
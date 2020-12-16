using System.ComponentModel.DataAnnotations;

namespace SEP3_Tier1.Validation
{
    public class PostCodeValidation : ValidationAttribute
    {
        public string GetErrorMessage() => "Postcode must be only four numbers";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            int toCheck = (int)value;

            if (toCheck.ToString().Length != 4) {
                return new ValidationResult(GetErrorMessage());
            }
            
            return ValidationResult.Success;
        }
    }
}
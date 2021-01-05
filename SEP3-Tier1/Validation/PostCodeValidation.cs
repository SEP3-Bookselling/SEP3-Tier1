using System.ComponentModel.DataAnnotations;

namespace SEP3_Tier1.Validation
{
    public class PostCodeValidation : ValidationAttribute
    {
        public string GetErrorMessage() => "Postcode must be only four numbers";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            string toCheck = (string)value;

            if (toCheck.Length != 4) {
                return new ValidationResult(GetErrorMessage());
            }
            
            return ValidationResult.Success;
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace RecruitingApi.Validation;

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime date && date <= DateTime.UtcNow)
            //                         ?? = Null-Coalescing Operator. Basically makes it so it provides this default "Date must be in the future." message unless the dev provided one which would fill ErrorMessage (they could provide one by doing [FutureDate(ErrorMessage = "blah blah") 
            return new ValidationResult(ErrorMessage ?? "Date must be in the future.");

        return ValidationResult.Success; 
    }
}


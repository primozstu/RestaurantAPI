using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validators;

// Validation for create restaurant is responsible createRestaurantCommandValidaator class
public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
{
    private readonly List<string> validCategories = ["italian", "mexican", "chinese", "japanese", "american", "polish"];
    public CreateRestaurantDtoValidator()
    {
        RuleFor(dto => dto.Name).MinimumLength(3).MaximumLength(100);
        RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required.");
        RuleFor(dto => dto.Category)
            .Must(validCategories.Contains);
            //.Custom((value, context) => { 
            //    var isValidCategory = validCategories.Contains(value.ToLower());
            //    if (!isValidCategory)
            //    {
            //        context.AddFailure("Category", "Invalid category");
            //    }
            //})
            //.NotEmpty();
        RuleFor(dto => dto.ContactEmail).EmailAddress();
        RuleFor(dto => dto.PostalCode).Matches(@"^\d{2}-\d{3}$");
    }
}

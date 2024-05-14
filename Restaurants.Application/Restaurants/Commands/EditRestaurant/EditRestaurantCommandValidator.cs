using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.EditRestaurant;

public class EditRestaurantCommandValidator: AbstractValidator<EditRestaurantCommand>
{
    public EditRestaurantCommandValidator()
    {
        RuleFor(x => x.Name).Length(3, 100).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Category).NotEmpty();
    }
}

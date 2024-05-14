using FluentValidation;
using Restaurants.Application.Dishes.Commands.CreateDish;

namespace Restaurants.Application.Dishes.Validators;

public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(dish => dish.Name).Length(3, 100).NotEmpty();
        RuleFor(dish => dish.Description).NotEmpty();
        RuleFor(dish => dish.Price).GreaterThanOrEqualTo(0);
        RuleFor(dish => dish.KiloCalories).GreaterThanOrEqualTo(0);
    }
}

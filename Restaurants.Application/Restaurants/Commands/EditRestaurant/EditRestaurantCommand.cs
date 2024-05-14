using MediatR;

namespace Restaurants.Application.Restaurants.Commands.EditRestaurant;

public class EditRestaurantCommand: IRequest
{
    public int Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
}

using Restaurants.Domain.Entites;

namespace Restaurants.Application.Restaurants.Dtos;

public class EditRestaurantDto
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
}

using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetAllDishesQuery;

public class GetAllDishesQuery(int resturantId): IRequest<IEnumerable<DishDto>>
{
    public int RestaurantId { get; set; } = resturantId;
}

using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entites;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteDish;

public class DeleteDishCommandHandler(ILogger<DeleteDishCommandHandler> logger, 
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteDishCommand>
{
    public async Task Handle(DeleteDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting dish with id : {request.DishId} for restaurant with id : {request.RestaurantId}");
        var restaurant = await restaurantsRepository.GetRestaurantById(request.RestaurantId);
        if (restaurant is null)
        {
            throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
        }
        var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId);
        if (dish is null)
        {
            throw new NotFoundException(nameof(Dish), request.DishId.ToString());
        }
        restaurant.Dishes.Remove(dish);
        await restaurantsRepository.UpdateAsync(restaurant);
    }
}

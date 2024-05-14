using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entites;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteAllDishes;

public class DeleteAllDishesCommandHandler(ILogger<DeleteAllDishesCommandHandler> logger, 
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteAllDishesCommand>
{
    public async Task Handle(DeleteAllDishesCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting all dishes for restaurant with id : {request.RestaurantId}");
        var restaurant = await restaurantsRepository.GetRestaurantById(request.RestaurantId);
        if (restaurant is null)
        {
            throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
        }
        restaurant.Dishes.Clear();
        await restaurantsRepository.UpdateAsync(restaurant);
    }
}

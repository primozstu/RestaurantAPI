using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entites;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.EditRestaurant;

public class EditRestaurantCommandHandler(ILogger<EditRestaurantCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IMapper mapper) : IRequestHandler<EditRestaurantCommand>
{
    public async Task Handle(EditRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Editing restaurant by id: {RestaurantId} with {@UpdatedRestaurant}", request.Id, request);
        var restaurant = await restaurantsRepository.GetRestaurantById(request.Id);
        if (restaurant is null)
        {
            throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
        }
        mapper.Map(request, restaurant);
       
        //restaurant.Name = request.Name;
        //restaurant.Description = request.Description;
        //restaurant.Category = request.Category;
        await restaurantsRepository.UpdateAsync(restaurant);
        // await restaurantsRepository.SaveChanges(restaurant);
    }
}


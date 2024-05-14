using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entites;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllDishesQuery;

public class GetAllDishesQueryHandler(ILogger<GetAllDishesQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IMapper mapper) : IRequestHandler<GetAllDishesQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetAllDishesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Retreving dihses for restaurant with id : {request.RestaurantId}");
        var restaurant = await restaurantsRepository.GetRestaurantById(request.RestaurantId);
        if (restaurant is null)
        {
            throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
        }
        var results =  mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);
        return results;
    }
}

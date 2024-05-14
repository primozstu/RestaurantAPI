using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entites;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDish;

public class GetDishQueryHandler(ILogger<GetDishQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IMapper mapper) : IRequestHandler<GetDishQuery, DishDto>
{
    public async Task<DishDto> Handle(GetDishQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Retreving dish with id : {request.DishId} for restaurant with id : {request.RestaurantId}");
        var resturant = await restaurantsRepository.GetRestaurantById(request.RestaurantId);
        if (resturant is null)
        {
            throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
        }
        var dish = resturant.Dishes.FirstOrDefault(d => d.Id == request.DishId);
        if (dish is null)
        {
            throw new NotFoundException(nameof(Dish), request.DishId.ToString());
        }
        var result = mapper.Map<DishDto>(dish);
        return result;
    }
}

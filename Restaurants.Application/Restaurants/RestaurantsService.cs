using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entites;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

// Using mediatR classes for handling requests, so we don't need to implement ResturantService and IRestaurantsService interface
//internal class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
//{
    //public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    //{
    //    logger.LogInformation("Getting all restaurants");
    //    var resturants = await restaurantsRepository.GetAllAsync();
    //    // var restaurantsDto = resturants.Select(RestaurantDto.FromEntity); // Without of automapper
    //    var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(resturants);    
    //    return restaurantsDtos!;
    //}

    //public async Task<RestaurantDto?> GetRestaurantById(int id)
    //{
    //    logger.LogInformation($"Getting restaurant by id {id}");
    //    var restaurant = await restaurantsRepository.GetRestaurantById(id);
    //    //var restaurantDto = RestaurantDto.FromEntity(restaurant); // Without of automapper

    //    var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);
    //    return restaurantDto;
    //}

    //public async Task<int> createRestaurant(CreateRestaurantDto createRestaurantDto)
    //{
    //    logger.LogInformation("Creating new restaurant");
    //    var restaurant = mapper.Map<Restaurant>(createRestaurantDto);
    //    int restaurantId = await restaurantsRepository.CreateAsync(restaurant);
    //    return restaurantId;
    //}
//}

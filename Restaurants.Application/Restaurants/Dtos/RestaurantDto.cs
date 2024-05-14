using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Restaurants.Dtos;

public class RestaurantDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool hasDelivery { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public List<DishDto> Dishes { get; set; } = [];

    // This method is not needed anymore because we are using AutoMapper
    //public static RestaurantDto? FromEntity(Restaurant? restaurant)
    //{
    //    if (restaurant is null)
    //    {
    //        return null;
    //    }
    //    return new RestaurantDto() { 
    //        Id = restaurant.Id,
    //        Name = restaurant.Name,
    //        Description = restaurant.Description,
    //        Category = restaurant.Category,
    //        hasDelivery = restaurant.hasDelivery,
    //        //Street = restaurant.Address?.Street,
    //        //City = restaurant.Address?.City,
    //        //PostalCode = restaurant.Address?.PostalCode,
    //        //Dishes = restaurant.Dishes.Select(DishDto.FromEntity).ToList()!
    //    };
    //}
}

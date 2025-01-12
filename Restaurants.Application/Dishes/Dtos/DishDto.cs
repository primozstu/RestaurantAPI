﻿using Restaurants.Domain.Entites;

namespace Restaurants.Application.Dishes.Dtos;

public class DishDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public int? KiloCalories { get; set; }

    // This method is not needed anymore because we are using AutoMapper
    //public static DishDto? FromEntity(Dish? dish)
    //{
    //    if (dish is null)
    //    {
    //        return null;
    //    }
    //    return new DishDto()
    //    {
    //        Id = dish.Id,
    //        Name = dish.Name,
    //        Description = dish.Description,
    //        Price = dish.Price,
    //        KiloCalories = dish.KiloCalories
    //    };
    //}
}

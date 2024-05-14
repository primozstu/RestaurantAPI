﻿using MediatR;
using Restaurants.Domain.Entites;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommand : IRequest<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool hasDelivery { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactNzumber { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
}

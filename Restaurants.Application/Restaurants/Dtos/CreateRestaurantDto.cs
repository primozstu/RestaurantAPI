using Restaurants.Domain.Entites;
using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.Restaurants.Dtos;

public class CreateRestaurantDto
{
    //[StringLength(100, MinimumLength = 3)] // Using FluentValidation instead of DataAnnotations
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    //[Required(ErrorMessage = "Insert a valid category")]   // Using FluentValidation instead of DataAnnotations
    public string Category { get; set; } = default!;
    public bool hasDelivery { get; set; }
    //[EmailAddress(ErrorMessage = "Insert a valid email")] // Using FluentValidation instead of DataAnnotations
    public string? ContactEmail { get; set; }
    //[Phone(ErrorMessage = "Insert a valid phone number")] // Using FluentValidation instead of DataAnnotations
    public string? ContactNzumber { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    //[RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Insert a valid postal code")] // Using FluentValidation instead of DataAnnotations
    public string? PostalCode { get; set; }
    public List<Dish> Dishes { get; set; } = new();
}

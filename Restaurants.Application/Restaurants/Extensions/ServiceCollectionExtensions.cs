using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Restaurants.Application.Restaurants.Extensions;

public static class ServiceCollectionsExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        //services.AddScoped<IRestaurantsService, RestaurantsService>(); // Using mediator for handling requests

        //var a = typeof(RestaurantDto);
        //var b = typeof(Restaurant);
        //var c = typeof(RestaurantsProfile);
        //var d = typeof(DishesProfile);
        //var e = typeof(ServiceCollectionExtensions);
        //var f = typeof(Dish);
        //var g = typeof(DishDto);
        //services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly); // This doesn't work

        //services.AddAutoMapper(typeof(RestaurantsProfile).Assembly, typeof(DishesProfile).Assembly);
        var assembly = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly).AddFluentValidationAutoValidation();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
    }
}


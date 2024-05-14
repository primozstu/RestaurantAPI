using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Entites;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastracture.Persistance;
using Restaurants.Infrastracture.Repositories;
using Restaurants.Infrastracture.Seeders;
namespace Restaurants.Infrastracture.Extensions;

public static class ServiceCollectionsExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RestaurantsDb");
        services.AddDbContext<RestaurantsDbContext>(options => 
            options.UseSqlServer(connectionString).EnableSensitiveDataLogging());
        // services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<RestaurantsDbContext>(); Not found
        services.AddIdentityCore<User>().AddEntityFrameworkStores<RestaurantsDbContext>();
        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
        services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
        services.AddScoped<IDishesRepository, DishesRepository>();
    }
}

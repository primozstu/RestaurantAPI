using Restaurants.Domain.Entites;
using Restaurants.Infrastracture.Persistance;

namespace Restaurants.Infrastracture.Seeders;

internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = [
            new Restaurant(){
                Name = "KFC",
                Category = "Fast Food",
                Description = "KFC is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken.",
                ContactEmail = "contact@kfc.com" ,
                hasDelivery = true,
                Dishes = [
                    new Dish(){
                        Name = "Chicken Wings",
                        Description = "Fried chicken wings",
                        Price = 10.99m,
                        RestaurantId = 1
                    },
                    new Dish(){
                        Name = "Chicken Burger",
                        Description = "Fried chicken burger",
                        Price = 5.99m,
                        RestaurantId = 1
                    }
                ],
                Address = new Address(){
                    City = "New York",
                    Street = "5th Avenue",
                    PostalCode = "10001"
                }
            },
            new Restaurant(){
                Name = "McDonalds",
                Category = "Fast Food",
                Description = "McDonald's Corporation is an American fast food company, founded in 1940 as a restaurant operated by Richard and Maurice McDonald, in San Bernardino, California, United States.",
                ContactEmail = "contact@mcdonald.com",
                hasDelivery = true,
                Address = new Address(){
                    City = "New York",
                    Street = "5th Avenue",
                    PostalCode = "10001"
                }
            }
        ];
        return restaurants;
    }
}

using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entites;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastracture.Persistance;

namespace Restaurants.Infrastracture.Repositories;

internal class RestaurantsRepository(RestaurantsDbContext dbContext) : IRestaurantsRepository
{
    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
       var resturants = await dbContext.Restaurants.ToListAsync();
       return resturants;
    }
    public async Task<Restaurant?> GetRestaurantById(int id)
    {
        var resturant = await dbContext.Restaurants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(r => r.Id == id);
        return resturant;
    }

    public async Task<int> CreateAsync(Restaurant restaurant)
    {
        await dbContext.Restaurants.AddAsync(restaurant);
        await dbContext.SaveChangesAsync();
        return restaurant.Id;
    }

    public async Task DeleteAsync(Restaurant entity)
    {
        dbContext.Restaurants.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Restaurant entity)
    {
        dbContext.Restaurants.Update(entity);
        await dbContext.SaveChangesAsync();
    }
}


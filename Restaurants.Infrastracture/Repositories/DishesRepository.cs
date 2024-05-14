using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entites;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastracture.Persistance;

namespace Restaurants.Infrastracture.Repositories;

internal class DishesRepository(RestaurantsDbContext dbContext) : IDishesRepository
{
    public async Task<int> Create(Dish entity)
    {
        dbContext.Dishes.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public Task Get(int id)
    {
        throw new NotImplementedException();
    }
}

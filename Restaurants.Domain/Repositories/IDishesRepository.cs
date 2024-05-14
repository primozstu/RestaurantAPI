using Restaurants.Domain.Entites;

namespace Restaurants.Domain.Repositories;

public interface IDishesRepository
{
    Task<int> Create(Dish entity);

    Task Get(int id);
}

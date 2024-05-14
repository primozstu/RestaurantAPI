using Restaurants.Domain.Entites;

namespace Restaurants.Domain.Repositories;

    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();

        Task<Restaurant?> GetRestaurantById(int id);

        Task<int> CreateAsync(Restaurant restaurant);

        Task DeleteAsync(Restaurant entity);

        Task UpdateAsync(Restaurant entity);
    }


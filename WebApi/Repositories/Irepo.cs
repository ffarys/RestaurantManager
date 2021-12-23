using WebApi.Models;

namespace WebApi.Repositories
{
    public interface Irepo
    {
        IEnumerable<Meal> GetAllMeals();

        Meal GetMealById(int id);
    }
}

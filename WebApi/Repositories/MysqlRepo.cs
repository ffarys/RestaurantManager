using WebApi.Contexts;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class MysqlRepo : Irepo
    {

        private readonly MealContext _context;

        public MysqlRepo(MealContext context)
        {
            _context = context;
        }
        public IEnumerable<Meal> GetAllMeals()
        {
            return _context.Meals;
        }

        public Meal GetMealById(int id)
        {
            return _context.Meals.FirstOrDefault<Meal>(t => t.Id == id);
        }
    }
}

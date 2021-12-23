using WebApi.Models;

namespace WebApi.Repositories
{
    public class MockMeal : Irepo
    {
        List<Meal> MealsList = new List<Meal>();

        public MockMeal()
        {
            MealsList.Add(new Meal() { Id = 1, Name = "stoofpot" });
            MealsList.Add(new Meal() { Id = 2, Name = "vol-au-vent" });
            MealsList.Add(new Meal() { Id = 3, Name = "aardappel stampot" });
        }

        public IEnumerable<Meal> GetAllMeals()
        {
            return MealsList;
        }
        public Meal GetMealById(int id)
        {
            Meal _meal = MealsList.FirstOrDefault<Meal>(t => t.Id == id);
            return _meal;
        }
    }

    
}

using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Contexts
{
    public class MealContext:DbContext
    {

        public MealContext(DbContextOptions<MealContext> opt):base(opt)
        {

        }

        public DbSet<Meal> Meals { get; set; }
    }
}

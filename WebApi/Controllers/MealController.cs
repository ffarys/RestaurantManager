using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/meal")]
    public class MealController : ControllerBase
    {


        private readonly Irepo _repo;

        public MealController(Irepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult GetAllMeals()
        {
            return Ok(_repo.GetAllMeals());
        }

        [HttpGet("{id}")]
        public ActionResult GetMealById(int id)
        {
            
            return Ok(_repo.GetMealById(id));
        }
    }
}

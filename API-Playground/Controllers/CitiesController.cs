
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace API_Playground.Controllers
{
    [ApiController]
    [Route("api/Cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult(CitiesDataStore.current.Cities);

        }
        [HttpGet("{id}")]
        public JsonResult GetCity(int id) {
            return new JsonResult(
                CitiesDataStore.current.Cities.FirstOrDefault(c => c.CitiesDataID == id));
               
        }
    }
}


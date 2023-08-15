
using API_Playground.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace API_Playground.Controllers
{
    [ApiController]
    [Route("api/Cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CitiesData>> GetCities()
        {
            return Ok (CitiesDataStore.current.Cities);

        }
        [HttpGet("{id}")]
        public ActionResult<CitiesData> GetCity(int id) {
            
            var CityToReturn =   
                CitiesDataStore.current.Cities.FirstOrDefault(c => c.CitiesDataID == id);

            if (CityToReturn == null)
            {
              return NotFound();
            }
                
            return Ok (CityToReturn);
        }   
    }
}



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
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return Ok (CitiesDataStore.current.Cities);

        }
        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id) {
            
            var CityToReturn =   
                CitiesDataStore.current.Cities.FirstOrDefault(c => c.CityDtoID == id);

            if (CityToReturn == null)
            {
              return NotFound();
            }
                
            return Ok (CityToReturn);
        }   
    }
}


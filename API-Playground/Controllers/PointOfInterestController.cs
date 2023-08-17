using API_Playground.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Playground.Controllers
{
    [Route("api/Cities/{CityID}/PointOfInterest")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointOfInterest(int cityId) 
        { 
            var city = CitiesDataStore.current.Cities.FirstOrDefault(c=>c.CityDtoID== cityId);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city.PointsOfInterst);
        }

        [HttpGet("{PointOfInterestID}")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest (int cityId, int pointofinterstId) {

            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.CityDtoID == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointofinterest = CitiesDataStore.current.Cities.FirstOrDefault(c => c.CityDtoID == cityId);
            if (pointofinterest == null)
            {
                return NotFound();
            }
            return Ok(pointofinterest);
        }
    }
}

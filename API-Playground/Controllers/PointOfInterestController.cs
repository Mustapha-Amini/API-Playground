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

        [HttpGet("{PointOfInterestID}" , Name ="GetPointOfInterest")]
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

        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest( int CityId,
            PointOfInterestForCreationDto pointofinterst)
        {
            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.CityDtoID ==  CityId);
            if(city == null)
            {
                return NotFound();
            }
            var maxPointOfInterestId = CitiesDataStore.current.Cities.SelectMany( c => c.PointOfInterest).Max(p => p.PointOfInterestDtoID);
            var finalPointOfInterst = new PointOfInterestDto()
            {
                PointOfInterestDtoID = ++ maxPointOfInterestId,
                PointOfInterestDtoName = pointofinterst.PointOfInterestForCreationDtoName,
                PointOfInterestDtoDescription =pointofinterst.PointOfInterstForCreationDtoDescription

            };
            city.PointOfInterest.Add(finalPointOfInterst);
            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    cityId=CityId,
                    pointofinterstId = finalPointOfInterst.PointOfInterestDtoID
                },
                    finalPointOfInterst);
        }

            
    }
}

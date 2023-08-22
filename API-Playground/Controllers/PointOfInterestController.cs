using API_Playground.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{pointofinterestid}" , Name ="GetPointOfInterest")]
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
        public ActionResult<PointOfInterestDto> CreatePointOfInterest( int cityId,
            PointOfInterestForCreationDto pointofinterst)
        {
            if( !ModelState.IsValid)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.CityDtoID ==  cityId);
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
                    cityId = cityId,
                    pointofinterstId = finalPointOfInterst.PointOfInterestDtoID
                },
                    finalPointOfInterst);
        }

        [HttpPut("{pointofinterestid}")] 
        public ActionResult UpdatePointOfIterest ( int cityId,int pointofinterstId,
            PointOfInterestForUpdateDto pointOfInterest)
        {
            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.CityDtoID == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointOfInterest
                .FirstOrDefault(c => c.PointOfInterestDtoID == pointofinterstId);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            pointOfInterestFromStore.PointOfInterestDtoName = pointOfInterest.PointOfInterestForUpdateDtoName;
            pointOfInterestFromStore.PointOfInterestDtoDescription = pointOfInterest.PointOfInterestForUpdateDtoDescription;

            return NoContent();
        }

        [HttpPatch("{pointofinterestid}")]
        public ActionResult PartiallyUpdatePointOfInterest(
            int cityId , int pointofinterstId,
            JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        {
            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.CityDtoID == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointOfInterest
                .FirstOrDefault(c => c.PointOfInterestDtoID == pointofinterstId);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }
            var pointOfInterestToPatch =
                   new PointOfInterestForUpdateDto()
                   {
                       PointOfInterestForUpdateDtoName = pointOfInterestFromStore.PointOfInterestDtoName,
                       PointOfInterestForUpdateDtoDescription = pointOfInterestFromStore.PointOfInterestDtoDescription
                   };

            patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pointOfInterestFromStore.PointOfInterestDtoName = pointOfInterestToPatch.PointOfInterestForUpdateDtoName;
            pointOfInterestFromStore.PointOfInterestDtoDescription = pointOfInterestToPatch.PointOfInterestForUpdateDtoDescription;

            return NoContent();
        }

        [HttpDelete("{pointOfInterestId}")]
        public ActionResult DeletPointOfInterst ( int cityId, int pointofinterestId)
        {
            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.CityDtoID == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointOfInterest
                .FirstOrDefault(c => c.PointOfInterestDtoID == pointofinterestId);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            city.PointOfInterest.Remove(pointOfInterestFromStore);
            return NoContent();
        }
    }

}

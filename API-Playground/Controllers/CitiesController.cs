
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
              return new JsonResult(
              new List <object> {
              new { id = 1, Name = "Tehran" },
              new { id = 2, Name = "Shiraz" }
               });
        }
    }
}

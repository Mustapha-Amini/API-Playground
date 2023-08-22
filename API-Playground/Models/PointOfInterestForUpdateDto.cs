using System.ComponentModel.DataAnnotations;

namespace API_Playground.Models
{
    public class PointOfInterestForUpdateDto
    {
        [Required(ErrorMessage = "You should select a Name")]
        [MaxLength(50)]
        public string PointOfInterestForUpdateDtoName { get; set; }

        [MaxLength(200)]
        public string PointOfInterestForUpdateDtoDescription { get; set; }

    }
}

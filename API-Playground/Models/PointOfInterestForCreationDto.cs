using System.ComponentModel.DataAnnotations;

namespace API_Playground.Models
{
    public class PointOfInterestForCreationDto
    {
        [Required(ErrorMessage ="Please enter a Name")]
        [MaxLength(50)]
        public string PointOfInterestForCreationDtoName { get; set; }

        [Required(ErrorMessage ="Please say something about that")]
        [MaxLength(200)]
        public string PointOfInterstForCreationDtoDescription { get; set; }
    }
}

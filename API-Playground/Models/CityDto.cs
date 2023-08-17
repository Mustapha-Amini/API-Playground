namespace API_Playground.Models
{
    public class CityDto
    {
        public int CityDtoID { get; set; }
        public string? CityName { get; set; }
        public string? CityDescription { get; set;}
        public int NumberOfPointOfInterst 
        {
            get
            {
                return PointOfInterest.Count;
            }
        }
        public ICollection<PointOfInterestDto> PointOfInterest { get; set; }
        = new List<PointOfInterestDto>();
        public object PointsOfInterst { get; internal set; }
    }
}

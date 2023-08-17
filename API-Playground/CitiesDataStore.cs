using API_Playground.Models;

namespace API_Playground
{
    public class CitiesDataStore
    {
        public List<CityDto>? Cities {get; set;}
        public static CitiesDataStore current { get;} = new CitiesDataStore();

        public CitiesDataStore() 
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                CityDtoID = 1,
                CityName = "Tehran",
                CityDescription = "This is in Iran , The capital!",
                PointOfInterest= new List<PointOfInterestDto>()
                
                {
                    new PointOfInterestDto()
                    {
                        PointOfInterestDtoID = 1,
                        PointOfInterestDtoName = "Milad Tower",
                        PointOfInterestDtoDescription = "It's the talest tower in Iran"
                    },

                    new PointOfInterestDto()
                    {
                        PointOfInterestDtoID = 2,
                        PointOfInterestDtoName = "Chitgar Lake",
                        PointOfInterestDtoDescription = "This is on the north of Tehran"
                    }
                }
                },
           
                new CityDto()
                {
                CityDtoID = 2,
                CityName = "Shiraz",
                CityDescription = "This is in South of Iran , The capital of culture of Iran!",
                PointOfInterest= new List<PointOfInterestDto>()
                {
                    new PointOfInterestDto()
                    {
                        PointOfInterestDtoID = 3,
                        PointOfInterestDtoName = "Ghoran Gate",
                        PointOfInterestDtoDescription ="This is an ancient art"
                    },

                    new PointOfInterestDto()
                    {
                        PointOfInterestDtoID= 4,
                        PointOfInterestDtoName = "Garden",
                        PointOfInterestDtoDescription ="There are many garden in this city"
                    },
                }
                },

                new CityDto()
                {
                CityDtoID = 3,
                CityName = "Varamin",
                CityDescription = "This is in capital of Iran , This town is one of oldest!",
                PointOfInterest= new List<PointOfInterestDto>()
                {
                    new PointOfInterestDto()
                    {
                        PointOfInterestDtoID =5,
                        PointOfInterestDtoName = "Toghrol Tower",
                        PointOfInterestDtoDescription = "This the oldest in Varamin",
                    },

                    new PointOfInterestDto()
                    {
                        PointOfInterestDtoID = 6,
                        PointOfInterestDtoName = "Gabri Castle",
                        PointOfInterestDtoDescription ="This is the importat castle in ancient for Persia",

                    }
                }
                }


            };
        }
    }
}

using API_Playground.Models;

namespace API_Playground
{
    public class CitiesDataStore
    {
        public List<CitiesData>? Cities {get; set;}
        public static CitiesDataStore current { get;} = new CitiesDataStore();

        public CitiesDataStore() 
        {
            Cities = new List<CitiesData>()
            {
                new CitiesData()
                {
                CitiesDataID = 1,
                CitiesName = "Tehran",
                CitiesDescription = "This is in Iran , The capital!"
                },
           
                new CitiesData()
                {
                CitiesDataID = 2,
                CitiesName = "Shiraz",
                CitiesDescription = "This is in South of Iran , The capital of culture of Iran!"
                },

                new CitiesData()
                {
                CitiesDataID = 3,
                CitiesName = "Varamin",
                CitiesDescription = "This is in capital of Iran , This town is one of oldest!"
                }


            };
        }
    }
}

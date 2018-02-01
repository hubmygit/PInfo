
namespace MapForm
{
    public class MapFormParams
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int radius { get; set; }
        public string connectionString { get; set; }
        public string apiKey { get; set; }
        public bool existsInternetConnection { get; set; }
    }

    public class MapFormGeoData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
    }
}

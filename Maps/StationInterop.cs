using System;

public class StationInterop
{   public int id;
    public string Name;
    public string Address;
    public string Address0;
}

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
    public int brand_id { get; set; }
}


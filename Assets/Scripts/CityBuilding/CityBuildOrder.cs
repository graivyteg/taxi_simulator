using System.Collections.Generic;

public class CityBuildOrder
{
    public List<Building> Buildings;
    public CityConfig Config;

    public CityBuildOrder(CityConfig config)
    {
        Buildings = new List<Building>();
        Config = config;
    }
}
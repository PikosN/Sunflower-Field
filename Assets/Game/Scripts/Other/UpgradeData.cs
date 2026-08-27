using System.Collections.Generic;

public class UpgradeData
{
    public string id;
    public string name;
    public string description;
    public int baseCost;

    public float costGrowthRate;
    public float effectRate;
}

public class AllUpgrades
{
    public static List<UpgradeData> all = new List<UpgradeData>
    {
        // Growth upgrade
        new UpgradeData()
        {
            id = "growth_1",
            name = "Fast growth",
            description = "Growth speed upgrade",
            baseCost = 20,
            costGrowthRate = 1.7f,
            effectRate = 0.9f,
            
},
        // Money upgrade
        new UpgradeData()
        {
            id = "money_1",
            name = "More money for plant",
            description = "Sunflower value upgrade",
            baseCost = 25,
            costGrowthRate = 1.8f,
            effectRate = 1.2f
        },
        // Autoharvest upgrade
        new UpgradeData()
        {
            id = "autoharvest",
            name = "Auto harvesting",
            description = "Don't waste your time!",
            baseCost = 100,
            costGrowthRate = 1f
        },
        //new UpgradeData()
        //{
            // id = "",
            // name = "",
            // description = "",
            // baseCost = 0,
            // costGrowthRate = 1f
        //},
    };
    public static UpgradeData GetUpgrade(string id)
    {
        return all.Find(upgrade => upgrade.id == id);
    }
}
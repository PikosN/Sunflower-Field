using System.Collections.Generic;

public class UpgradeData
{
    public string id;
    public string name;
    public string description;
    public int baseCost;
    public int amountOfUpgrades;

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
            id = "growth",
            name = "Fast growth",
            description = "Growth speed upgrade",
            baseCost = 20,
            amountOfUpgrades = 100,
            costGrowthRate = 1.7f,
            effectRate = 0.9f,
            
},
        // Money upgrade
        new UpgradeData()
        {
            id = "money",
            name = "More money for plant",
            description = "Sunflower value upgrade",
            baseCost = 25,
            amountOfUpgrades = 100,
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
            amountOfUpgrades = 1,
            costGrowthRate = 1f
        },
        //new UpgradeData()
        //{
            //id = "",
            //name = "",
            //description = "",
            //baseCost = 0,
            //amountOfUpgrades = 0,
            //costGrowthRate = 0f,
            //effectRate = 0f
        //},
    };
    public static UpgradeData GetUpgrade(string id)
    {
        return all.Find(upgrade => upgrade.id == id);
    }
}
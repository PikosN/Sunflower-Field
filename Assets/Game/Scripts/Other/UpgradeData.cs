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
    public bool showStats = false;
}

public class AllUpgrades
{
    public static List<UpgradeData> all = new List<UpgradeData>
    {
        // Growth upgrade
        new UpgradeData()
        {
            id = "growth",
            name = "[00] BETTER LAMPS",
            description = "Plants grow 10% faster",
            baseCost = 20,
            amountOfUpgrades = 10,
            costGrowthRate = 1.7f,
            effectRate = 0.9f,
            showStats = true,
            
},
        // Money upgrade
        new UpgradeData()
        {
            id = "money",
            name = "[01] FERTILIZERS",
            description = "The value of plants increases",
            baseCost = 25,
            amountOfUpgrades = 10,
            costGrowthRate = 1.8f,
            effectRate = 1.2f,
            showStats = true,
        },
        // Autoharvest upgrade
        new UpgradeData()
        {
            id = "autoharvest",
            name = "[02] AUTOHARVESTING",
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
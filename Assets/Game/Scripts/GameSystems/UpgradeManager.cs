using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public int growthLevel = 0;
    public int moneyLevel = 0;
    public int hasAutoharvest = 0;
    public void ApplyUpgrade(UpgradeData upgrade)
    {
        switch (upgrade.id)
        {
            case "growth":
                UpgradeGrowth();
                break;
            case "money":
                UpgradeMoney();
                break;
            case "autoharvest":
                UpgradeAutoharvest();
                break;
        }
    }

    public int GetUpgradeLevel(string id)
    {
        switch (id)
        {
            case "growth":
                return growthLevel;
            case "money":
                return moneyLevel;
            case "autoharvest":
                return hasAutoharvest;
            default: 
                return 0;
        }
    }
    
    void UpgradeGrowth()
    {
        growthLevel++;
    }

    void UpgradeMoney()
    {
        moneyLevel++;
    }

    void UpgradeAutoharvest()
    {
        hasAutoharvest = 1;
    }

    public void Reset()
    {
        growthLevel = 0;
        moneyLevel = 0;
        hasAutoharvest= 0;
    }
}

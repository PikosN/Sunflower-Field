using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public int growthLevel = 0;
    public int moneyLevel = 0;
    public int hasAutoharvest = 0;
    public int bonusChanceLevel = 0;
    public int bonusMoneyLevel = 0;

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
            case "bonus_chance":
                UpgradeBonusChance();
                break;
            case "bonus_money":
                UpgradeBonusMoney();
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
            case "bonus_chance":
                return bonusChanceLevel;
            case "bonus_money":
                return bonusMoneyLevel;
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

    void UpgradeBonusChance()
    {
        bonusChanceLevel++;
    }

    void UpgradeBonusMoney()
    {
        bonusMoneyLevel++;
    }

    public void Reset()
    {
        growthLevel = 0;
        moneyLevel = 0;
        hasAutoharvest= 0;
        bonusChanceLevel = 0;
        bonusMoneyLevel = 0;
    }
}

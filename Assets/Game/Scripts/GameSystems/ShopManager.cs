using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shopPanel;
    public EconomyManager economyManager;
    public UpgradeManager upgradeManager;
    public UpgradeCard upgradeCardPrefab;
    public Transform content;
    public TMP_Text FPMoneyText;
    private bool isOpen = false;
    void Start()
    {
        shopPanel.SetActive(false);
        CreateUpgrade("growth_1");
        CreateUpgrade("money_1");
        CreateUpgrade("autoharvest");
    }

    public void CreateUpgrade(string id)
    {
        UpgradeData upgrade = AllUpgrades.GetUpgrade(id);
        UpgradeCard card = Instantiate(upgradeCardPrefab, content);
        card.Setup(upgrade);
    }

    public bool BuyUpgrade(UpgradeData upgrade)
    {
        int cost = GameMath.GetUpgradeCost(
            upgrade.baseCost,
            upgrade.costGrowthRate,
            G.upgradeManager.GetUpgradeLevel(upgrade.id)
            );
        if (!economyManager.TrySpentMoney(cost))
        {
            return false;
        }
        upgradeManager.ApplyUpgrade(upgrade);
        return true;
    }

    public void OpenShop()
    {
        isOpen = true;
        shopPanel.SetActive(true);
        FPMoneyText.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseShop()
    {
        isOpen = false;
        shopPanel.SetActive(false);
        FPMoneyText.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    public bool IsOpen() { return isOpen; }
}

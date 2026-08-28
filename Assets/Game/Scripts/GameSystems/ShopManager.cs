using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shopPanel;
    public UpgradeCard upgradeCardPrefab;
    public Transform content;
    public TMP_Text FPMoneyText;

    public List<UpgradeCard> activeUpgradeCards;

    private bool isOpen = false;
    void Start()
    {
        shopPanel.SetActive(false);
    }

    public void CreateUpgrade(string id)
    {
        UpgradeData upgrade = AllUpgrades.GetUpgrade(id);
        UpgradeCard card = Instantiate(upgradeCardPrefab, content);
        card.Setup(upgrade);
        activeUpgradeCards.Add(card);
    }

    public bool BuyUpgrade(UpgradeData upgrade)
    {
        int cost = GameMath.GetUpgradeCost(
            upgrade.baseCost,
            upgrade.costGrowthRate,
            G.upgradeManager.GetUpgradeLevel(upgrade.id)
            );
        if (!G.economyManager.TrySpentMoney(cost))
        {
            return false;
        }
        G.upgradeManager.ApplyUpgrade(upgrade);
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

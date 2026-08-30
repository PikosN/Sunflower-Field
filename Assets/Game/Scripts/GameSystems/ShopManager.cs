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
        shopPanel.SetActive(true);
        FPMoneyText.enabled = false;

        G.player.SetMovementEnabled(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        FPMoneyText.enabled = true;

        G.player.SetMovementEnabled(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Reset()
    {
        while (activeUpgradeCards.Count > 0)
        {
            activeUpgradeCards[0].Delete();
        }

        CreateUpgrade("growth");
        CreateUpgrade("money");
        CreateUpgrade("autoharvest");
    }
}

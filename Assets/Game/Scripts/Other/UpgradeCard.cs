using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCard : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public TMP_Text costText;
    public Button buyButton;

    private UpgradeData upgrade;
    public void Setup(UpgradeData cardData)
    {
        upgrade = cardData;

        descriptionText.text = cardData.description;
        
        Refresh();

        buyButton.onClick.AddListener(BuyAndApply);
    }
    void BuyAndApply()
    {
        int cost = GameMath.GetUpgradeCost(
            upgrade.baseCost,
            upgrade.costGrowthRate,
            G.upgradeManager.GetUpgradeLevel(upgrade.id)
            );
        if (G.economyManager.TrySpentMoney(cost))
        {
            G.upgradeManager.ApplyUpgrade(upgrade);
            if (G.upgradeManager.GetUpgradeLevel(upgrade.id) < upgrade.amountOfUpgrades)
            {
                Refresh();
            }
            else
            {
                SetPurchased();
            }
        }
    }
    public void Refresh()
    {
        int cost = GameMath.GetUpgradeCost(
            upgrade.baseCost,
            upgrade.costGrowthRate,
            G.upgradeManager.GetUpgradeLevel(upgrade.id)
            );
        int level = G.upgradeManager.GetUpgradeLevel(upgrade.id);

        nameText.text = upgrade.name + " " + level;
        costText.text = cost + "$";
    }

    public void Delete()
    {
        G.shopUI.activeUpgradeCards.Remove(this);
        Destroy(gameObject);
    }

    void SetPurchased()
    {
        buyButton.interactable = false;
        costText.text = "";
        buyButton.GetComponentInChildren<TMP_Text>().text = "PURCHASED";
    }
}

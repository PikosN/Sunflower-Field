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

        nameText.text = cardData.name;
        descriptionText.text = cardData.description;
        
        RefreshCost();

        buyButton.onClick.AddListener(Buy);
    }
    void Buy()
    {

        if (G.shopManager.BuyUpgrade(upgrade))
        {
            if (G.upgradeManager.GetUpgradeLevel(upgrade.id) < upgrade.amountOfUpgrades)
            {
                RefreshCost();
            }
            else
            {
                SetPurchased();
            }
        }
    }
    public void RefreshCost()
    {
        int cost = GameMath.GetUpgradeCost(
            upgrade.baseCost,
            upgrade.costGrowthRate,
            G.upgradeManager.GetUpgradeLevel(upgrade.id)
            );
        costText.text = cost + "$";
    }

    public void Delete()
    {
        Destroy(gameObject);
    }

    void SetPurchased()
    {
        buyButton.interactable = false;
        costText.text = "";
        buyButton.GetComponentInChildren<TMP_Text>().text = "PURCHASED";
    }
}

using UnityEngine;

public class SunflowerSpot : MonoBehaviour, IInteractable
{
    public GameObject SunflowerVisual;
    private enum State
    {
        Empty,
        Growing,
        Ready
    }
    private State state = State.Empty;
    private float growTimer;

    public void Interact()
    {
        if (state == State.Empty) Plant();
        if (state == State.Ready) Harvest();
    }
    public string GetInteractText()
    {
        if (state == State.Empty)
        {
            int sunflowerCost = GameMath.GetSunflowerCost(
                SunflowerData.baseCost,
                SunflowerData.costGrowthRate,
                G.plantManager.currentSunflowers
            );
            return "Press E to plant sunflower for " + sunflowerCost + "$";
        }
        if (state == State.Growing)
        {
            return "Sunflower is growing...";
        }
        if (state == State.Ready)
        {
            return "Press E to harvest";
        }
        
        return "";
    }

    void Plant()
    {
        int sunflowerCost = GameMath.GetSunflowerCost(
            SunflowerData.baseCost,
            SunflowerData.costGrowthRate,
            G.plantManager.currentSunflowers
            );
        if (!G.economyManager.TrySpentMoney(sunflowerCost))
        {
            return;
        }
        G.plantManager.BuySunflower();
        SunflowerVisual.SetActive(true);
        state = State.Growing;
        growTimer = 0f;

        G.plantManager.sunflowerSpots.Add(this);
    }

    void Harvest()
    {
        SunflowerVisual.SetActive(false);
        SunflowerVisual.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        int moneyPerPlant = GameMath.GetMoneyPerPlant(
                SunflowerData.baseReward,
                AllUpgrades.GetUpgrade("money_1").effectRate,
                G.upgradeManager.GetUpgradeLevel("money_1")
            );
        G.economyManager.AddMoney(moneyPerPlant);

        SunflowerVisual.SetActive(true);
        state = State.Growing;
        growTimer = 0f;
    }
    void Update()
    {
        if (state != State.Growing) return;

        growTimer += Time.deltaTime;
        float growthTime = GameMath.GetGrowthTime(
                SunflowerData.baseGrowthTime,
                AllUpgrades.GetUpgrade("growth_1").effectRate,
                G.upgradeManager.GetUpgradeLevel("growth_1")
            );
        float progress = Mathf.Clamp01(growTimer / growthTime);

        SunflowerVisual.transform.localScale = new Vector3(0.1f, progress * 2.5f, 0.1f);
        SunflowerVisual.transform.localPosition = new Vector3(0f, progress * 2.5f / 2, 0f);

        if (growTimer >= growthTime)
        {
            state = State.Ready;
        }
    }

    public void Reset()
    {
        state = State.Empty;

        SunflowerVisual.SetActive(false);
        SunflowerVisual.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
}

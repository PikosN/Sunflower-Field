using UnityEngine;

public class PlantSpot : MonoBehaviour, IInteractable
{
    public GameObject plantVisual;
    private enum State
    {
        Empty,
        Growing,
        Ready
    }
    private State state = State.Empty;
    private float growTimer;
    private PlantData plantData;

    public void Interact()
    {
        if (state == State.Empty) G.plantSelectionUI.OpenUI(this);
        if (state == State.Ready) Harvest();
    }
    public string GetInteractText()
    {
        if (state == State.Empty)
        {
            return "Press E to plant";
        }
        if (state == State.Growing)
        {
            return "Plant is growing...";
        }
        if (state == State.Ready)
        {
            return "Press E to harvest";
        }
        
        return "";
    }

    public void Plant(PlantData plant)
    {
        plantData = plant;
        plantVisual.SetActive(true);
        state = State.Growing;
        growTimer = 0f;

        G.plantManager.BuyPlant();
        G.plantManager.plantSpots.Add(this);
    }

    void Harvest()
    {
        plantVisual.SetActive(false);
        plantVisual.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        int moneyPerPlant = GameMath.GetMoneyPerPlant(
                plantData.baseReward,
                AllUpgrades.GetUpgrade("money").effectRate,
                G.upgradeManager.GetUpgradeLevel("money")
            );
        G.economyManager.AddMoney(moneyPerPlant);

        plantVisual.SetActive(true);
        state = State.Growing;
        growTimer = 0f;
    }
    void Update()
    {
        if (state != State.Growing) return;

        if (!G.lightManager.isLightOn) return;

        growTimer += Time.deltaTime;
        float growthTime = GameMath.GetGrowthTime(
                plantData.baseGrowthTime,
                AllUpgrades.GetUpgrade("growth").effectRate,
                G.upgradeManager.GetUpgradeLevel("growth")
            );
        float progress = Mathf.Clamp01(growTimer / growthTime);

        plantVisual.transform.localScale = Vector3.one * progress * 2.5f;
        plantVisual.transform.localPosition = new Vector3(0f, 0.35f, 0f);

        if (growTimer >= growthTime)
        {
            if (G.upgradeManager.GetUpgradeLevel("autoharvest") == 1)
            {
                Harvest();
            }
            else
            {
                state = State.Ready;
            }
        }
    }

    public void Reset()
    {
        state = State.Empty;

        plantVisual.SetActive(false);
        plantVisual.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
}

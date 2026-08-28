using Unity.VisualScripting;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    float dayProgress;
    public float progress;
    int dayGoal;
    public bool isDayCompleted;

    void Start()
    {
        StartDay();
    }

    public void StartDay()
    {
        foreach (var upgradeCard in G.shopManager.activeUpgradeCards)
        {
            upgradeCard.Delete();
        }
        G.shopManager.CreateUpgrade("growth");
        G.shopManager.CreateUpgrade("money");
        G.shopManager.CreateUpgrade("autoharvest");

        foreach (var plantCard in G.plantSelectionUI.activePlantCards)
        {
            plantCard.Delete();
        }
        G.plantSelectionUI.activePlantCards.Add(G.plantSelectionUI.CreatePlantCard("sunflower"));

        dayProgress = 0f;
        progress = 0f;
        isDayCompleted = false;

        dayGoal = GameMath.GetDayGoal(500, G.prestigeManager.currentDay);
    }
    public void AddProgress(int amount)
    {
        if (isDayCompleted)
        {
            return;
        }
        dayProgress += amount;
        progress = Mathf.Clamp01(dayProgress / dayGoal);
        if (progress >= 1)
        {
            isDayCompleted = true;
        }
    }
}

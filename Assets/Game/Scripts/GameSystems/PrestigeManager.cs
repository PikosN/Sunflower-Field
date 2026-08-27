using UnityEngine;

public class PrestigeManager : MonoBehaviour
{
    public int prestigeLevel = 0;
    public int currentDay = 1;
    public void Prestige()
    {
        prestigeLevel++;
        currentDay++;

        G.upgradeManager.Reset();
        G.economyManager.Reset();
        G.plantManager.Reset();

        G.progressManager.StartDay();
    }
}

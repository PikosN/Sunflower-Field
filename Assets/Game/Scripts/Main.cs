using UnityEngine;

public class Main : MonoBehaviour
{
    public EconomyManager economyManager;
    public ShopManager shopManager;
    public UpgradeManager upgradeManager;
    public PlantManager plantManager;
    public PrestigeManager prestigeManager;
    public ProgressManager progressManager;
    public DayNightManager dayNightManager;
    void Awake()
    {
        G.economyManager = economyManager;
        G.shopManager = shopManager;
        G.upgradeManager = upgradeManager;
        G.plantManager = plantManager;
        G.prestigeManager = prestigeManager;
        G.progressManager = progressManager;
        G.dayNightManager = dayNightManager;
    }
}

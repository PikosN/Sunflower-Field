using UnityEngine;

public class Main : MonoBehaviour
{
    public EconomyManager economyManager;
    public ShopManager shopManager;
    public UpgradeManager upgradeManager;
    public PlantManager plantManager;
    public PrestigeManager prestigeManager;
    public ProgressManager progressManager;
    public PlantSelectionUI plantSelectionUI;
    public Player player;
    void Awake()
    {
        G.economyManager = economyManager;
        G.shopManager = shopManager;
        G.upgradeManager = upgradeManager;
        G.plantManager = plantManager;
        G.prestigeManager = prestigeManager;
        G.progressManager = progressManager;
        G.plantSelectionUI = plantSelectionUI;
        G.player = player;

        StartGame();
    }

    void StartGame()
    {
        G.progressManager.StartDay();
    }
}

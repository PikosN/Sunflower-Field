using UnityEngine;

public class Main : MonoBehaviour
{
    public EconomyManager economyManager;
    public ShopManager shopManager;
    public UpgradeManager upgradeManager;
    public PlantManager plantManager;
    void Awake()
    {
        G.economyManager = economyManager;
        G.shopManager = shopManager;
        G.upgradeManager = upgradeManager;
        G.plantManager = plantManager;
    }
}

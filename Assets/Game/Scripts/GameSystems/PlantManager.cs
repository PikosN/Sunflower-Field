using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public List<PlantSpot> plantSpots;
    public int currentPlants = 0;

    void Start()
    {
        G.lightManager.OnLightsTurnedOff += OffAllGrowthbars;
        G.lightManager.OnLightsTurnedOn += OnAllGrowthbars;
    }

    private void OnDestroy()
    {
        G.lightManager.OnLightsTurnedOff -= OffAllGrowthbars;
        G.lightManager.OnLightsTurnedOn -= OnAllGrowthbars;
    }

    public void BuyPlant()
    {
        currentPlants++;
    }
    
    void OffAllGrowthbars()
    {
        foreach (var plantSpot in plantSpots)
        {
            plantSpot.growthBar.SetActive(false);
        }
    }

    void OnAllGrowthbars()
    {
        foreach (var plantSpot in plantSpots)
        {
            plantSpot.growthBar.SetActive(true);
        }
    }

    public void Reset()
    {
        foreach (var plantSpot in plantSpots)
        {
            plantSpot.Reset();
        }

        plantSpots.Clear();

        currentPlants = 0;
    }
}

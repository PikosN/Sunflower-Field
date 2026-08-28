using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public List<PlantSpot> plantSpots;
    public int currentPlants = 0;

    public void BuyPlant()
    {
        currentPlants++;
    }
    
    public void Reset()
    {
        foreach (var plantSpot in plantSpots)
        {
            plantSpot.Reset();
        }
        currentPlants = 0;
    }
}

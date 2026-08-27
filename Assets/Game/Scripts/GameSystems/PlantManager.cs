using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public List<SunflowerSpot> sunflowerSpots;
    public int currentSunflowers = 0;

    public void BuySunflower()
    {
        currentSunflowers++;
    }
    
    public void Reset()
    {
        foreach (var sunflowerSpot in sunflowerSpots)
        {
            sunflowerSpot.Reset();
        }
        currentSunflowers = 0;
    }
}

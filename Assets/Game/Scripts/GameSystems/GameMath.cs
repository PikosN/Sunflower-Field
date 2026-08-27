using System;
using UnityEngine;

public static class GameMath
{
    public static int GetSunflowerCost(int baseCost, float sunflowerRate, int currentSunflowers)
    {
        int sunflowerCost = Mathf.RoundToInt(baseCost * Mathf.Pow(sunflowerRate, currentSunflowers));
        return sunflowerCost;
    }
    public static float GetGrowthTime(float baseTime, float growthRate, int level)
    {
        float sunflowerGrowthTime = baseTime * Mathf.Pow(growthRate, level);
        return sunflowerGrowthTime;
    }
    public static int GetMoneyPerPlant(int baseMoney, float moneyRate, int level)
    {
        int moneyPerPlant = Mathf.RoundToInt(baseMoney * Mathf.Pow(moneyRate, level));
        return moneyPerPlant;
    }
    public static int GetUpgradeCost(int baseCost, float costGrowthRate, int level)
    {
        return Mathf.RoundToInt(baseCost * Mathf.Pow(costGrowthRate, level));
    }
}

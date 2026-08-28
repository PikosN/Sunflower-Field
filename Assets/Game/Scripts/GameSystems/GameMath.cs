using System;
using UnityEngine;

public static class GameMath
{
    public static int GetPlantCost(int baseCost, float plantRate, int currentPlants)
    {
        int sunflowerCost = Mathf.RoundToInt(baseCost * Mathf.Pow(plantRate, currentPlants));
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
    public static int GetDayGoal(int baseDayGoal, int day)
    {
        return Mathf.RoundToInt(baseDayGoal * Mathf.Pow(2f, day - 1));
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public SleepAnimation sleepAnimation;

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
        StartCoroutine(sleepAnimation.Wakeup());

        G.shopUI.Reset();

        G.plantSelectionUI.Reset();

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

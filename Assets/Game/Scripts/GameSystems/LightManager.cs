using System;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Lamp[] Lamps;

    void Awake()
    {
        Lamps = FindObjectsByType<Lamp>();
    }

    public bool isLightOn = true;
    public event Action OnLightsTurnedOff;
    public event Action OnLightsTurnedOn;

    public void TurnOffLights()
    {
        isLightOn = false;

        OnLightsTurnedOff?.Invoke();

        foreach (Lamp lamp in Lamps)
        {
            lamp.SetEnabled(false);
        }
    }
    public void TurnOnLights()
    {
        isLightOn = true;

        OnLightsTurnedOn?.Invoke();

        foreach (Lamp lamp in Lamps)
        {
            lamp.SetEnabled(true);
        }
    }
}

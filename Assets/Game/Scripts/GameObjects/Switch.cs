using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (!G.lightManager.isLightOn)
        {
            G.lightManager.TurnOnLights();
        }
    }

    public string GetInteractText()
    {
        if (G.lightManager.isLightOn)
        {
            return "Light switch";
        }
        else
        {
            return "Press E to turn lights on";
        }
    }
}

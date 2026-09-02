using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (!G.lightManager.isLightOn)
        {
            StartCoroutine(G.lightManager.TurnOnLights());
        }
        else
        {
            G.lightManager.TurnOffLights();
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

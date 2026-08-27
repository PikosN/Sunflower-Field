using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (G.progressManager.isDayCompleted == true)
        {
            G.prestigeManager.Prestige();
        }
    }
    public string GetInteractText()
    {
        if (G.progressManager.isDayCompleted == true)
        {
            return "Go to sleep";
        }
        else
        {
            return "You don't want to sleep. You need to work.";
        }
        
    }
}

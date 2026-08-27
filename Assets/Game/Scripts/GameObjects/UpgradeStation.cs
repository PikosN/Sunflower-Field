using UnityEngine;

public class UpgradeStation : MonoBehaviour, IInteractable
{
    public string interactText = "Press E to open the shop";
    public void Interact()
    {
        G.shopManager.OpenShop();
    }
    public string GetInteractText() { return interactText; }

}

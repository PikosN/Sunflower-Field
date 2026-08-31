using UnityEngine;

public class UpgradeStation : MonoBehaviour, IInteractable
{
    public string interactText = "Press E to open the shop";
    public void Interact()
    {
        G.shopUI.OpenShop();
    }
    public string GetInteractText() { return interactText; }

}

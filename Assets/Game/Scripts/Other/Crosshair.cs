using TMPro;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GameObject interactableUI;
    public GameObject defaultCrosshair;
    public TMP_Text interactableText;

    public void SetInteractableUI(bool value, string text)
    {
        interactableUI.SetActive(value);
        interactableText.text = text;
        defaultCrosshair.SetActive(!value);
    }
}

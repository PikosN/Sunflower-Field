using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject interactableUI;
    public GameObject defaultCrosshair;
    public TMP_Text interactableText;

    public void SetInteractableUI(bool value, string text)
    {
        interactableUI.SetActive(value);
        interactableText.text = text;
        defaultCrosshair.SetActive(!value);
    }

    public void SetUIEnabled(bool enabled)
    {
        canvas.SetActive(enabled);
    }
}

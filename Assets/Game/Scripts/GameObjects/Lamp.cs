using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Renderer lightsRenderer;
    public Light lightSource;

    private Material material;

    private Color emissionColor = new Color32(94, 0, 95, 255);
    private float emissionIntensity = 1f;

    void Awake()
    {
        material = lightsRenderer.materials[1];
    }

    public void SetEnabled(bool enabled)
    {
        lightSource.enabled = enabled;

        if (enabled)
        {
            material.SetColor("_BaseColor", new Color32(255, 0, 217, 255));
            material.SetColor("_EmissionColor", emissionColor * emissionIntensity);
        }
        else
        {
            material.SetColor("_BaseColor", Color.gray * 0.1f);
            material.SetColor("_EmissionColor", Color.gray * 0.1f);
        }
    }
}

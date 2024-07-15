using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class BrightnessSlider : MonoBehaviour
{
    [SerializeField] private Material gammaMaterial;

    public void SetGamma(float gamma)
    {
        // Set the brightness value on the material
        gammaMaterial.SetFloat("_Gamma", gamma);
    }
}

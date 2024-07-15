using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class BrightnessSlider : MonoBehaviour
{
    [SerializeField] private Material gammaMaterial;

    public void SetGamma(float value)
    {
        // Set the brightness value on the material
        gammaMaterial.SetFloat("_Gamma", value);
    }
}

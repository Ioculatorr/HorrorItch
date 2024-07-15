using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] private Light lightBulb;
    [SerializeField] private GameObject bulb;
    [SerializeField] private Material glow;
    [SerializeField] private Material noglow;

    public void OnInteract()
    {
        switch(lightBulb.enabled)
        {
            case true:

                lightBulb.enabled = false;
                bulb.gameObject.GetComponent<MeshRenderer>().material = noglow;

                break;

            case false:

                lightBulb.enabled = true;
                bulb.gameObject.GetComponent<MeshRenderer>().material = glow;

                break;
        }
    }
}

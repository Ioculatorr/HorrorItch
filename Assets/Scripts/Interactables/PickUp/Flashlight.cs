using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private Light flashlight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            switch (flashlight.enabled)
            {
                case true:

                    flashlight.enabled = false;

                    break;

                case false:

                    flashlight.enabled = true;

                    break;
            }
        }
    }
}

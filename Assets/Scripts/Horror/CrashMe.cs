using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashMe : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            Application.Quit();
        }
    }
}

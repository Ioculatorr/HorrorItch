using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RenderSettings.fog = false;
            Debug.Log("fog off");
        }
    }
}

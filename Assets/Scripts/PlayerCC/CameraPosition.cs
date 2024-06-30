using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private GameObject Camera;

    // Update is called once per frame
    void Update()
    {
        Camera.transform.position = this.transform.position;    
    }
}

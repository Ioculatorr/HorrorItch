using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class PlayerCam : MonoBehaviour
{
    
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform cmCamera;
    [SerializeField] private CinemachineVirtualCamera CinemachineCamera;

    public float sensX = 400f;
    public float sensY = 400f;
    
    private float xRotation;
    private float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Camera locked on start
        this.enabled = false;
        Invoke("UnlockCamera", 2f);

    }

    // My own camera movement script, legacy because of cool Cinemachine POV feature.

    private void UnlockCamera()
    {
        this.enabled = true;
    }
    
    private void LateUpdate()
    {
        // // Get mouse input
        //float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        //float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        
        //yRotation += mouseX;
        //xRotation -= mouseY;
        
        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        //Rotate cam
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        
        // Rotate orientation needed for movement
        
        orientation.rotation = Quaternion.Euler(0, cmCamera.transform.rotation.eulerAngles.y, 0);

    }
}

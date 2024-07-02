using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteraction : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionRange = 2f;
    public LayerMask interactableLayerMask;

    [Header("FMOD")]

    [SerializeField] private EventReference fmodEvent; // Assign the FMOD event path in the Inspector

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Assuming left mouse button for interaction
        {
            Interact();
        }
    }

    void Interact()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        FMODUnity.RuntimeManager.PlayOneShot(fmodEvent, transform.position);
        Debug.DrawRay(transform.position, transform.forward * interactionRange, Color.red, 2f);

        if (Physics.Raycast(ray, out hit, interactionRange, interactableLayerMask))
        {

            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.OnInteract();
            }
        }
    }
}

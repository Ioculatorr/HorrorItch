using UnityEngine;
using System.Collections;

public class FootstepsSound : MonoBehaviour
{
    [SerializeField] private float distanceT;
    [SerializeField] private AudioSource footstepsTest;
    //public EventReference FootstepEvent;

    //private FMOD.Studio.EventInstance footstepInstance;
    private Vector3 lastPosition;
    public LayerMask LayerMask;

    private void Start()
    {
        lastPosition = transform.position;
        //footstepInstance = FMODUnity.RuntimeManager.CreateInstance(FootstepEvent); // Default to wood footstep event

        // Start the coroutine to check distance periodically
        StartCoroutine(CheckDistance());
    }

    private IEnumerator CheckDistance()
    {
        while (true)
        {
            // Calculate the distance moved since the last check
            float distanceMoved = Vector3.Distance(transform.position, lastPosition);
            float footstepDistanceThreshold = distanceT;

            // If distance moved is greater than the threshold, update footstep event and play sound
            if (distanceMoved > footstepDistanceThreshold)
            {
                UpdateFootstepEvent();
                PlayFootstepSound();
                lastPosition = transform.position;
            }

            // Wait for a short duration before checking again
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void UpdateFootstepEvent()
    {
        // Raycast down to detect the surface beneath the player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f))
        {
            int layer = hit.collider.gameObject.layer;

            // Check the layer and update the footstep event accordingly
            if (layer == LayerMask.NameToLayer("Wood"))
            {
                //footstepInstance.setParameterByNameWithLabel("Surface", "Wood");
            }
            else if (layer == LayerMask.NameToLayer("Normal"))
            {
                //footstepInstance.setParameterByNameWithLabel("Surface", "Normal");
            }
            // Add more cases for other layers if needed
        }
    }

    private void PlayFootstepSound()
    {
        // Play the FMOD event
        //footstepInstance.start();
        footstepsTest.Play();
        Debug.Log("Sound played!");
    }
}


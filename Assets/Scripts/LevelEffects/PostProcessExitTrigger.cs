using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PostProcessExitTrigger : MonoBehaviour
{
    [SerializeField] private Volume darkPlacePostProcess;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            // Tween the weight value to 1.0f over 1 second (you can change the duration as needed)
            DOTween.To(() => darkPlacePostProcess.weight, x => darkPlacePostProcess.weight = x, 0.0f, 1.0f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClockScript : MonoBehaviour
{
    [SerializeField] private float dayDuration = 2f;

    private void Start()
    {
        this.transform.DORotate( new Vector3 (0, 0, 360), dayDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)     // Ensure the rotation is linear
            .SetLoops(-1, LoopType.Restart);   // Loop indefinitely
    }
}

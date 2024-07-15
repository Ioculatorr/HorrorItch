using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CassettePlayer : MonoBehaviour
{
    [SerializeField] private GameObject cassette;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cassette01"))
        {
            Debug.Log("Playing a record");

            Destroy(other.gameObject);

            cassette.SetActive(true);

            cassette.transform.DOMoveX(6.5f, 2f);
        }
    }

    private void Start()
    {
        cassette.SetActive(false);
    }
}
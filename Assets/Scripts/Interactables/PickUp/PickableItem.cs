using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class PickableItem : MonoBehaviour, IInteractable
{
    [SerializeField] private NonPhysPickUp pickupSystem; // To be changed
    public ItemSO itemData;

    public void OnInteract()
    {
        pickupSystem.PickUpItem(this.gameObject);
    }
}

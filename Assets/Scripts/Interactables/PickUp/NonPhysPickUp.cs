using UnityEngine;

public class NonPhysPickUp : MonoBehaviour
{
    [SerializeField] private Transform pickPoint;
    [SerializeField] private float throwForce = 10f;

    private GameObject currentItem;
    private ItemSO currentItemData;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentItem != null)
        {
            DropItem();
        }
        if (Input.GetMouseButtonDown(1) && currentItem != null)
        {
            ThrowItem();
        }
    }

    public void PickUpItem(GameObject item)
    {
        if (currentItem == null)
        {
            currentItem = item;

            currentItemData = item.GetComponent<PickableItem>().itemData;

            item.transform.position = pickPoint.position;
            item.transform.rotation = pickPoint.rotation;
            item.transform.parent = pickPoint;
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.GetComponent<Collider>().enabled = false;


            switch (currentItemData.itemName)
            {
                case "Flashlight":

                    item.GetComponent<Flashlight>().enabled = true;

                    break;

                case "Default":

                    break;
            }

            // Notify the system of the picked-up item
            Debug.Log("Picked up item: " + currentItemData.itemName);
        }
    }

    public void DropItem()
    {
        if (currentItem != null)
        {
            currentItem.transform.parent = null;
            currentItem.GetComponent<Rigidbody>().isKinematic = false;
            currentItem.GetComponent<Collider>().enabled = true;


            // Check if the current item has a Flashlight component before disabling it
            Flashlight flashlight = currentItem.GetComponent<Flashlight>();
            if (flashlight != null)
            {
                flashlight.enabled = false;
            }


            // Let go off item

            currentItem = null;
            currentItemData = null;

        }
    }

    private void ThrowItem()
    {
        if (currentItem != null)
        {
            currentItem.transform.parent = null;
            currentItem.GetComponent<Rigidbody>().isKinematic = false;
            currentItem.GetComponent<Collider>().enabled = true;

            currentItem.GetComponent<Rigidbody>().AddForce(pickPoint.transform.forward * throwForce, ForceMode.Impulse);
            //currentItem.GetComponent<Rigidbody>().velocity = pickPoint.forward * throwForce;



            // Turned off functionalities

            // Check if the current item has a Flashlight component before disabling it
            Flashlight flashlight = currentItem.GetComponent<Flashlight>();
            if (flashlight != null)
            {
                flashlight.enabled = false;
            }

            // Let go off item

            currentItem = null;
            currentItemData = null;
        }
    }
}

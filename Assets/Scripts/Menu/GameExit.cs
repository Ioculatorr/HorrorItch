using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour, IInteractable
{
    [SerializeField] private CanvasGroup exitMenu;

    public void OnInteract()
    {
        exitMenu.alpha = 1f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Sleep()
    {
        Debug.Log("Good night");
        Application.Quit();
    }

    public void Live()
    {
        exitMenu.alpha = 0f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

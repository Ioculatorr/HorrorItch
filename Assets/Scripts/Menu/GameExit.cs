using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor;

public class GameExit : MonoBehaviour, IInteractable
{
    [SerializeField] private CanvasGroup exitMenu;
    [SerializeField] private Image blackoutImg;
    [SerializeField] private PlayerMovementCC playerMovement;
    [SerializeField] private Transform camPos;

    public void OnInteract()
    {
        exitMenu.alpha = 1f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        playerMovement.enabled = false;

        exitMenu.interactable = true;
        exitMenu.blocksRaycasts = true;
    }

    public void Sleep()
    {

        camPos.transform.DOMove(this.transform.position, 2f);

        blackoutImg.DOFade(1f, 3f).OnComplete(() =>
        {
            Debug.Log("Good night");
            Application.Quit();
        });
    }

    public void Live()
    {
        exitMenu.alpha = 0f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        playerMovement.enabled = true;

        exitMenu.interactable = false;
        exitMenu.blocksRaycasts = false;
    }
}

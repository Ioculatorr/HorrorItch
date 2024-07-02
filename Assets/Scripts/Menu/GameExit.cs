using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameExit : MonoBehaviour, IInteractable
{
    [SerializeField] private CanvasGroup exitMenu;
    [SerializeField] private Image blackoutImg;

    public void OnInteract()
    {
        exitMenu.alpha = 1f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Sleep()
    {

        blackoutImg.DOFade(1f, 2f).OnComplete(() =>
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
    }
}

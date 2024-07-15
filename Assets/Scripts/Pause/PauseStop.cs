using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseStop : MonoBehaviour
{
    [SerializeField] private CanvasGroup pauseCanvas;
    [SerializeField] private CinemachineVirtualCamera cameravc;

    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (isPaused)
            {
                case true:

                    pauseCanvas.DOFade(0f, 1f);
                    pauseCanvas.interactable = false;
                    pauseCanvas.blocksRaycasts = false;

                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;

                    cameravc.enabled = true;

                    isPaused = false;

                    break;

                case false:

                    pauseCanvas.DOFade(1f, 1f);
                    pauseCanvas.interactable = true;
                    pauseCanvas.blocksRaycasts = true;

                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;

                    isPaused = true;

                    cameravc.enabled = false;

                    break;
            }
        }
    }

    public void MainMenuExit()
    {
        SceneManager.LoadScene(0);
    }
}

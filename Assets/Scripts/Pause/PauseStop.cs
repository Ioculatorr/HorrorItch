using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseStop : MonoBehaviour
{
    [SerializeField] private CanvasGroup pauseCanvas;
    [SerializeField] private CinemachineVirtualCamera cameravc;
    [SerializeField] private Rigidbody rb;

    private bool isPaused = false;

    private Vector3 savedVelocity;
    private Vector3 savedAngularVelocity;

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

                    ResumeRigidbody();


                    break;

                case false:

                    pauseCanvas.DOFade(1f, 1f);
                    pauseCanvas.interactable = true;
                    pauseCanvas.blocksRaycasts = true;

                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;

                    isPaused = true;

                    PauseRigidbody();
                    cameravc.enabled = false;

                    break;
            }
        }
    }

    public void MainMenuExit()
    {
        SceneManager.LoadScene(0);
    }

    private void PauseRigidbody()
    {
        if (rb != null)
        {
            // Save the current velocity and angular velocity
            savedVelocity = rb.velocity;
            savedAngularVelocity = rb.angularVelocity;

            // Stop the Rigidbody
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            rb.isKinematic = true;
        }
    }

    private void ResumeRigidbody()
    {
        if (rb != null)
        {
            rb.isKinematic = false;
            
            // Restore the saved velocity and angular velocity
            rb.velocity = savedVelocity;
            rb.angularVelocity = savedAngularVelocity;
        }
    }
}

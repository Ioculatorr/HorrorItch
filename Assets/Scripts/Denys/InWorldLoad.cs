using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InWorldLoad : MonoBehaviour, IInteractable
{
    public Slider loadingSlider;

    public string[] scenes; // Array of scene names

    private AsyncOperation asyncOperation;
    private bool loadedBool = false;
    private string selectedScene; // Variable to store the randomly selected scene

    public void OnInteract()
    {

        switch (loadedBool)
        {
            case true:

                OnContinueButtonClicked();


                break;

            case false:

                StartCoroutine(LoadSceneAsync());

                break;
        }
    }

    IEnumerator LoadSceneAsync()
    {
        // Randomly select a scene from the array
        selectedScene = scenes[Random.Range(0, scenes.Length)];
        Debug.Log(selectedScene);

        asyncOperation = SceneManager.LoadSceneAsync(selectedScene, LoadSceneMode.Additive);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            // Update the slider value
            loadingSlider.value = asyncOperation.progress;
            if (asyncOperation.progress >= 0.9f)
            {
                loadingSlider.value = 1f; // Set the slider value to 1 when done
                loadedBool = true;
                break;
            }
            yield return null;
        }
    }

    void OnContinueButtonClicked()
    {
        asyncOperation.allowSceneActivation = true;
    }
}

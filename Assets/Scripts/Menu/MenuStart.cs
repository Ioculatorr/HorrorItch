using DG.Tweening;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuStart : MonoBehaviour
{
    [SerializeField] private CanvasGroup blackout;
    [SerializeField] private CanvasGroup settingsMenu;
    [SerializeField] private Material noiseShader;
    [SerializeField] private Material tripShader;

    private bool settingsOpen = false;

    private void Start()
    {
        blackout.alpha = 1f;

        blackout.DOFade(0f, 8f).SetEase(Ease.InQuad);


    }

    public void LoadLevel()
    {
        blackout.DOFade(1f, 2f).OnComplete(() =>
        {
            blackout.DOFade(1f, 2f).OnComplete(() =>
            {
                SceneManager.LoadScene(1);

            });
        });
    }

    public void ShaderTest()
    {
        noiseShader.DOFloat(1f, "_Alpha", 2f).OnComplete(() =>
        {
            noiseShader.DOFloat(0f, "_Alpha", 2f);
        });
    }

    public void ShaderTestRed()
    {
        tripShader.DOColor(new Color( 2f, 0f, 0f), "_Color", 2f);
    }

    public void ShaderTestGreen()
    {
        tripShader.DOColor(new Color(0f, 2f, 0f), "_Color", 2f);
    }

    public void SettingsOpenClose()
    {
        switch (settingsOpen)
        {
            case true:

                settingsMenu.DOFade(0f, 0.1f).OnComplete(() =>
                {
                    settingsMenu.interactable = false;
                    settingsMenu.blocksRaycasts = false;

                    settingsOpen = false;
                });

                break;

            case false:

                settingsMenu.DOFade(1f, 0.1f).OnComplete(() =>
                {
                    settingsMenu.interactable = true;
                    settingsMenu.blocksRaycasts = true;

                    settingsOpen = true;
                });

                break;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

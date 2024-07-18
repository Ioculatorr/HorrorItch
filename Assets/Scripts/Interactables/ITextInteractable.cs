using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using FMODUnity;
using System.Diagnostics.Tracing;

public class ITextInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image imageCanvas;
    [SerializeField] private CanvasGroup groupCanvas;
    [SerializeField] private RectTransform rectTransform;

    [SerializeField] private InteractionSO objectData;

    [SerializeField] private EventReference fmodEventPath;


    public void OnInteract()
    {
        if (text != null)
        {
            text.text = objectData.interactionText;
        }

        if (imageCanvas != null)

        {
            imageCanvas.sprite = objectData.interactionSprite;
        }

        groupCanvas.DOFade(1f, 0.1f);
        //rectTransform.DOMoveX(1920, 2f)
        //     .SetEase(Ease.Linear);

        RuntimeManager.PlayOneShot(fmodEventPath);

        StartCoroutine(HideText());
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(5f);

        groupCanvas.DOFade(0f, 1f);
        //rectTransform.DOMoveX(-1920, 2f)
        //    .SetEase(Ease.Linear);
    }




}

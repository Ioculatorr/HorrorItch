using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHighlightHandler2 : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private MenuStart menuStart;

    public void OnPointerEnter(PointerEventData eventData)
    {
        menuStart.ShaderTestRed();
    }
}
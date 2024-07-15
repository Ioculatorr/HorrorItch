using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHighlightHandler : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private MenuStart menuStart;

    public void OnPointerEnter(PointerEventData eventData)
    {
        menuStart.ShaderTestGreen();
    }
}
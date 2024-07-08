using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewInteractionData", menuName = "Interaction Data", order = 51)]
public class InteractionSO : ScriptableObject
{
    public string interactionText;
    public Sprite interactionSprite;
}
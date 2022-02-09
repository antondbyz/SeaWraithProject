using UnityEngine;
using UnityEngine.EventSystems;

public class GameButton : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public bool IsHolding { get; private set; }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsHolding = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsHolding = false;
    }
}

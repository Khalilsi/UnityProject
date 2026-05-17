using UnityEngine;
using UnityEngine.EventSystems;

public class StoryPanelHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RoomMenuManager roomMenuManager;
    public int panelIndex;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (roomMenuManager != null)
            roomMenuManager.OnPanelHoverEnter(panelIndex);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (roomMenuManager != null)
            roomMenuManager.OnPanelHoverExit(panelIndex);
    }
}

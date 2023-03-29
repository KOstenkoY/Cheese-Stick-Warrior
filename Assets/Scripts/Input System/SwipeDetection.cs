using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeDetection : InputSystem, IBeginDragHandler, IDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        // detection vertical swipes
        if(Mathf.Abs(eventData.delta.x) < Mathf.Abs(eventData.delta.y))
        {
            if(eventData.delta.y > 0)     //swipe up
            {
                JumpPressed();
            }
            else                          // swipe down
            {
                SlidePressed();
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class TouchDetection : InputSystem, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 _startScreenPosition;
    private Vector2 _finishScreenPosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        _startScreenPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _finishScreenPosition = eventData.position;

        if(GetTouch(_startScreenPosition, _finishScreenPosition))
        {
            FirePressed();
        }
    }

    private bool GetTouch(Vector2 startPos, Vector2 finishPos)
    {
        return (_startScreenPosition - _finishScreenPosition) == Vector2.zero;
    }
}

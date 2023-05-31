using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static event Action<bool> OnJump;
    public static event Action<bool> OnSlide;
    public static event Action<bool> OnStop;
    public static event Action<bool> OnAccelerationRun;
    public static event Action OnFire;

    protected void JumpPressed()
    {
        OnJump?.Invoke(true);
    }

    protected void SlidePressed()
    {
        OnSlide?.Invoke(true);
    }

    protected void FirePressed()
    {
        OnFire?.Invoke();
    }

    public void StopButtonPressed(bool isPressed)
    {
        OnStop?.Invoke(isPressed);
    }

    public void AccelerationRunButtonPressed(bool isPressed)
    {
        OnAccelerationRun?.Invoke(isPressed);
    }
}

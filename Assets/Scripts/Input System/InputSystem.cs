using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static event Action<bool> OnJump;
    public static event Action<bool> OnSlide;
    public static event Action<bool> OnStop;
    public static event Action<bool> OnAccelerationRun;
    public static event Action<bool> OnFire;

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
        OnFire?.Invoke(true);
    }

    protected void StopButtonPressed()
    {
        OnStop?.Invoke(true);
    }

    protected void AccelerationRunButtonPressed()
    {
        OnAccelerationRun?.Invoke(true);
    }
}

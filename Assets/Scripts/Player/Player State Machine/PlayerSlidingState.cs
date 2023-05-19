using System.Collections;
using UnityEngine;
using DG.Tweening;

public class PlayerSlidingState : PlayerBaseState
{
    public PlayerSlidingState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory)
    {
        IsRootState = true;
        InitializeSubState();
    }

    public override void CheckSwitchStates()
    {
        if(!Ctx.IsSliding || Ctx.IsJumpPressed)
        {
            // when player jump, stop sliding and cansel IsJumpPressed
            Ctx.IsJumpPressed = false;

            SwitchState(Factory.Grounded());
        }
    }

    public override void EnterState()
    {
        Ctx.CurrentSlideResetRoutine = Ctx.StartCoroutine(ISlideResetRoutine());

        Ctx.IsSliding = true;
    }

    public override void ExitState()
    {
        Ctx.IsSlidePressed = false;
        Ctx.IsSliding = false;

        Ctx.StopCoroutine(Ctx.CurrentSlideResetRoutine);

        StopSliding();
    }

    public override void InitializeSubState()
    {
        if (Ctx.IsAccelerationRunPressed)
        {
            SetSubState(Factory.AccelerationRun());
        }
        else if (Ctx.IsStopPressed)
        {
            SetSubState(Factory.Idle());
        }
        else
        {
            SetSubState(Factory.Run());
        }
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    private IEnumerator ISlideResetRoutine()
    {
        // logic for sliding
        
        //
        
        Ctx.transform.DORotate(Vector3.forward * 70, Ctx.DurationSliding);

        yield return new WaitForSeconds(Ctx.DurationSliding);

        Ctx.transform.DORotate(Vector3.zero, Ctx.DurationSliding - 0.3f);

        Ctx.IsSliding = false;
    }

    private IEnumerator IStartSlidingRoutine()
    {
        Ctx.transform.DORotate(Vector3.forward * 70, Ctx.DurationSliding);

        yield return new WaitForSeconds(Ctx.DurationSliding);

        Ctx.IsSlidePressed = false;
    }

    private void StopSliding()
    {
        Ctx.transform.DORotate(Vector3.zero, Ctx.DurationSliding - 0.3f);
    }
}

using System.Collections;
using UnityEngine;

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
        if(Ctx.IsStopPressed)
        {
            SwitchState(Factory.Idle());
        }
        else if (Ctx.IsJumpPressed)
        {
            SwitchState(Factory.Idle());
        }
    }

    public override void EnterState()
    {
        Ctx.CurrentSlideResetRoutine = Ctx.StartCoroutine(ISlideResetRoutine());
    }

    public override void ExitState()
    {
        Ctx.StopCoroutine(Ctx.CurrentSlideResetRoutine);
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
        yield return new WaitForSeconds(0.5f);
    }
}

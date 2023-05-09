public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base (currentContext, playerStateFactory)
    {
        IsRootState = true;
        InitializeSubState();
    }

    public override void CheckSwitchStates()
    {
        // if player is grounded and jump is pressed, switch to jump state
        if (Ctx.IsJumpPressed)
        {
            SwitchState(Factory.Jump());
        }
        else if (Ctx.IsSlidePressed)
        {
            SwitchState(Factory.Slide());
        }
    }

    public override void EnterState()
    {
        UnityEngine.Debug.Log("Grounded State!");
    }

    public override void ExitState()
    {
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
}

public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base (currentContext, playerStateFactory)
    {
        InitializeSubState();
    }

    public override void CheckSwitchStates()
    {
        // if player is grounded and jump is pressed, switch to jump state
        if (_ctx.IsJumpPressed)
        {
            SwitchState(_factory.Jump());
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
        if (_ctx.IsSlidePressed)
        {
            SetSubState(_factory.Slide());
        }
        else if (_ctx.IsStopPressed)
        {
            SetSubState(_factory.Idle());
        }
        else
        {
            SetSubState(_factory.Run());
        }
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }
}

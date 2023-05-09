public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory)
    {

    }

    public override void CheckSwitchStates()
    {
        if (!Ctx.IsStopPressed)
        {
            SwitchState(Factory.Run());
        }
        else if (Ctx.IsAccelerationRunPressed)
        {
            SwitchState(Factory.AccelerationRun());
        }
    }

    public override void EnterState()
    {
        Ctx.AppliedMovementX = 0;
    }

    public override void ExitState()
    {
        
    }

    public override void InitializeSubState()
    {
        
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }
}

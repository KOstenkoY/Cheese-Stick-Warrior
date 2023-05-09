public class PlayerAccelerationState : PlayerBaseState
{
    public PlayerAccelerationState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) 
        : base (currentContext, playerStateFactory) { }

    public override void CheckSwitchStates()
    {
        if (Ctx.IsStopPressed)
        {
            SwitchState(Factory.Idle());
        }
        else if(!Ctx.IsAccelerationRunPressed)
        {
            SwitchState(Factory.Run());
        }
    }

    public override void EnterState()
    {
        Ctx.AppliedMovementX = Ctx.RunningSpeed * Ctx.AccelerationMultiplier;
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

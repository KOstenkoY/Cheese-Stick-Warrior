public class PlayerRunningState : PlayerBaseState
{
    public PlayerRunningState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory)
    {

    }

    public override void CheckSwitchStates()
    {
        if (_ctx.IsStopPressed)
        {
            SwitchState(_factory.Idle());
        }
        else if (_ctx.IsSlidePressed)
        {
            SwitchState(_factory.Slide());
        }
    }

    public override void EnterState()
    {
       
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

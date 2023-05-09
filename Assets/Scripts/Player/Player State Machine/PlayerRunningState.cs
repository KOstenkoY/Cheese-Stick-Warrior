using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    public PlayerRunningState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory)
    {

    }

    public override void CheckSwitchStates()
    {
        if (Ctx.IsStopPressed)
        {
            SwitchState(Factory.Idle());
        }
        else if (Ctx.IsAccelerationRunPressed)
        {
            SwitchState(Factory.AccelerationRun());
        }
    }

    public override void EnterState()
    {
        Ctx.AppliedMovementX = Ctx.RunningSpeed;
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
        Ctx.transform.Translate(Vector3.forward * Ctx.AppliedMovementX * Time.deltaTime);
    }
}

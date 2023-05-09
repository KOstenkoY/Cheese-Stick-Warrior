using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    private const float _rayDistance = 0.2f;
    // coefficient for finding the lower coordinate of the player from which the ray is launched
    private const float _coefficient = 2.05f;

    public PlayerJumpingState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory)
    {
        IsRootState = true;
        InitializeSubState();
    }

    public override void CheckSwitchStates()
    {
        if(Physics2D.Raycast(Ctx.transform.position - new Vector3(0, Ctx.transform.localScale.y * _coefficient), Vector3.down, _rayDistance))
        {
            SwitchState(Factory.Grounded());
        }
    }

    public override void EnterState()
    {
        HandleJump();
    }

    public override void ExitState()
    {
        Ctx.IsJumpPressed = false;
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

    private void HandleJump()
    {
        bool _isGrounded = Physics2D.Raycast(Ctx.transform.position - new Vector3(0, Ctx.transform.localScale.y * _coefficient), Vector3.down, _rayDistance);

        if (_isGrounded)
        {
            Ctx.Rigidbody.AddForce(Vector3.up * Ctx.JumpForce, ForceMode2D.Impulse);
        }
    }
}

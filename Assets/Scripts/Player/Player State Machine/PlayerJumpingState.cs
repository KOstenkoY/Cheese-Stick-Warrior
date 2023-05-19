using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    private const float _rayDistance = 0.2f;

    public PlayerJumpingState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory)
    {
        IsRootState = true;
        InitializeSubState();
    }

    public override void CheckSwitchStates()
    {
        if(Ctx.IsGrounded)
        {
            SwitchState(Factory.Grounded());
        }
        else if (Ctx.IsSlidePressed)
        {
            // when player swipe down, increase gravity scale and cansel IsSlidePressed
            Ctx.Rigidbody.gravityScale = Ctx.GravityConstantScale * Ctx.GravityMultiplier;

            Ctx.IsSlidePressed = false;
        }
    }

    public override void EnterState()
    {
        HandleJump();

        Ctx.IsGrounded = false;
    }

    public override void ExitState()
    {
        Ctx.IsJumpPressed = false;

        Ctx.Rigidbody.gravityScale = Ctx.GravityConstantScale;
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
        bool _isGrounded = Physics2D.Raycast(Ctx.transform.position, Vector3.down, _rayDistance);

        if (_isGrounded)
        {
            Ctx.Rigidbody.AddForce(Vector3.up * Ctx.JumpForce, ForceMode2D.Impulse);
        }
    }
}

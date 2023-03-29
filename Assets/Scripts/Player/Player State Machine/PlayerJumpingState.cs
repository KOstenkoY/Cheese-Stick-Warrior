using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    private const float _rayDistance = 0.2f;
    // coefficient for finding the lower coordinate of the player from which the ray is launched
    private const float _coefficient = 2.05f;

    public PlayerJumpingState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory)
    {

    }

    public override void CheckSwitchStates()
    {
        if(Physics2D.Raycast(_ctx.transform.position - new Vector3(0, _ctx.transform.localScale.y * _coefficient), Vector3.down, _rayDistance))
        {
            SwitchState(_factory.Grounded());
        }
    }

    public override void EnterState()
    {
        HandleJump();
    }

    public override void ExitState()
    {
        _ctx.IsJumpPressed = false;
    }

    public override void InitializeSubState()
    {
        
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    private void HandleJump()
    {
        bool _isGrounded = Physics2D.Raycast(_ctx.transform.position - new Vector3(0, _ctx.transform.localScale.y * _coefficient), Vector3.down, _rayDistance);

        if (_isGrounded)
        {
            _ctx.Rigidbody.AddForce(Vector3.up * _ctx.JumpForce, ForceMode2D.Impulse);
        }
    }
}

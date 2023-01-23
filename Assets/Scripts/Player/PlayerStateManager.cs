using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    private PlayerBaseState _currentState;
    public PlayerIdleState idleState = new PlayerIdleState();
    public PlayerRunnignState runningState = new PlayerRunnignState();
    public PlayerJumpingState jumpingState = new PlayerJumpingState();
    public PlayerSlidingState slidingState = new PlayerSlidingState();

    private void Start()
    {
        // starting state for the state machine
        _currentState = runningState;

        _currentState.EnterState(this);
    }

    private void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        _currentState = state;
        state.EnterState(this);
    }
}

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class PlayerStateMachine : MonoBehaviour
{
    private Rigidbody2D _rigidbody = null;
    private CapsuleCollider2D _capsuleCollider = null;

    private PlayerBaseState _currentState;
    private PlayerStateFactory _states;

    private bool _isJumpPressed = false;
    private bool _isSlidePressed = false;
    private bool _isStopPressed = false;
    private bool _isAccelerationRunPressed = false;

    [SerializeField] private float _jumpForce = 20f;

    public Rigidbody2D Rigidbody { get { return _rigidbody; } }
    public CapsuleCollider2D CapsuleCollider { get { return _capsuleCollider; } }
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }

    public float JumpForce { get { return _jumpForce; } }

    public bool IsJumpPressed { get { return _isJumpPressed; } set { _isJumpPressed = value; } }
    public bool IsSlidePressed { get{ return _isSlidePressed; } set { _isSlidePressed = value; } }
    public bool IsStopPressed { get{ return _isStopPressed; } set { _isStopPressed = value; } }
    public bool IsAccelerationRunPressed { get { return _isAccelerationRunPressed; } set { _isAccelerationRunPressed = value; } }

    private void OnEnable()
    {
        InputSystem.OnJump += Jump;
        InputSystem.OnSlide += Slide;
        InputSystem.OnStop += Stop;
        InputSystem.OnAccelerationRun += AccelerationRun;
    }

    private void OnDisable()
    {
        InputSystem.OnJump -= Jump;
        InputSystem.OnSlide -= Slide;
        InputSystem.OnStop -= Stop;
        InputSystem.OnAccelerationRun -= AccelerationRun;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>();

        _states = new PlayerStateFactory(this);

        _currentState = _states.Grounded();

        _currentState.EnterState();
    }

    void Update()
    {
        _currentState.UpdateState();
    }

    private void Jump(bool _isPressed)
    {
        _isJumpPressed = _isPressed;
    }

    private void Slide(bool _isPressed)
    {
        _isSlidePressed = _isPressed;
    }

    private void Stop(bool _isPressed)
    {
        _isStopPressed = _isPressed;
    }

    private void AccelerationRun(bool _isPressed)
    {
        _isAccelerationRunPressed = _isPressed;
    }
}

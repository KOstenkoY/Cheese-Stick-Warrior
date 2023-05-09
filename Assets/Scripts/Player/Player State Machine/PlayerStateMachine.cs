using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private float _runningSpeed = 3f;
    [SerializeField] private float _accelerationMultiplier = 3f;
    private float _appliedMovementX;

    [SerializeField] private float _jumpForce = 20f;

    [SerializeField] private float _durationSliding = 0.5f;

    private Rigidbody2D _rigidbody = null;
    private CapsuleCollider2D _capsuleCollider = null;

    private PlayerBaseState _currentState;
    private PlayerStateFactory _states;

    private bool _isJumpPressed = false;
    private bool _isSlidePressed = false;
    private bool _isStopPressed = false;
    private bool _isAccelerationRunPressed = false;


    private Coroutine _currentSlideResetRoutine = null;

    public Rigidbody2D Rigidbody { get { return _rigidbody; } }
    public CapsuleCollider2D CapsuleCollider { get { return _capsuleCollider; } }
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }

    public bool IsJumpPressed { get { return _isJumpPressed; } set { _isJumpPressed = value; } }
    public bool IsSlidePressed { get{ return _isSlidePressed; } set { _isSlidePressed = value; } }
    public bool IsStopPressed { get{ return _isStopPressed; } set { _isStopPressed = value; } }
    public bool IsAccelerationRunPressed { get { return _isAccelerationRunPressed; } set { _isAccelerationRunPressed = value; } }

    public float RunningSpeed { get { return _runningSpeed; } }
    public float JumpForce { get { return _jumpForce; } }
    public float AppliedMovementX { get { return _appliedMovementX; } set { _appliedMovementX = value; } }
    public float AccelerationMultiplier { get { return _accelerationMultiplier; } set { _accelerationMultiplier = value; } }
    public float DurationSliding { get { return _durationSliding; } }

    public Coroutine CurrentSlideResetRoutine { get { return _currentSlideResetRoutine; } set { _currentSlideResetRoutine = value; } }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>();

        _appliedMovementX = _runningSpeed;

        _states = new PlayerStateFactory(this);

        _currentState = _states.Grounded();

        _currentState.EnterState();
    }

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

    void Update()
    {
        _currentState.UpdateStates();

        transform.Translate(Vector2.right * _appliedMovementX * Time.deltaTime);
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

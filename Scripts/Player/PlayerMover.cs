using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerAnimation), typeof(GroundObserver))]
public class PlayerMover : MonoBehaviour
{
    private const string HorizontalInput = "Horizontal";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigidbody;
    private PlayerAnimation _playerAnimation;
    private GroundObserver _ground;
    private float _horizontalDirection = 0f;
    private bool _isGrounded = false;
    private bool _isJumping = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _ground = GetComponent<GroundObserver>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void OnEnable()
    {
        _ground.OnLanded += HandleLanded;
        _ground.OnAirborne += HandleAirborne;
    }

    private void OnDisable()
    {
        _ground.OnLanded -= HandleLanded;
        _ground.OnAirborne -= HandleAirborne;
    }

    private void Update()
    {
        ReadInput();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        HandleJump();
        ChangeMoveDirection();
    }

    private void ReadInput()
    {
        _horizontalDirection = Input.GetAxis(HorizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isJumping = true;
        }
    }

    private void ChangeMoveDirection()
    {
        if (_horizontalDirection > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (_horizontalDirection < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    private void ApplyMovement()
    {
        _rigidbody.velocity = new Vector2(_horizontalDirection * _speed, _rigidbody.velocity.y);
    }

    private void HandleJump()
    {
        if (_isJumping)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isJumping = false;
        }
    }

    private void AnimatePlayer()
    {
        _playerAnimation.SetWalk(_horizontalDirection != 0);
        _playerAnimation.SetJump(!_isGrounded);
    }

    private void HandleLanded()
    {
        _isGrounded = true;
    }

    private void HandleAirborne()
    {
        _isGrounded = false;
    }
}

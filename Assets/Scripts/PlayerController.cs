using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector3 startPosition;

    public float movementSpeed = 5f;
    public float jumpForce = 10f;
    public int direction = 1;

    private InputAction _moveAction;
    private Vector2 _moveDirection;
    private InputAction _jumpAction;

    public Rigidbody2D rigidbody2D;

    private SpriteRenderer _render;
    private Animator _animator;

    private GroundSensor _sensor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start ()
    {
        transform.position = startPosition;
    }
    void Awake()
    {
         rigidbody2D = GetComponent<Rigidbody2D>();
        _render = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        _moveAction = InputSystem.actions["Move"];
        _jumpAction = InputSystem.actions["Jump"];

        _sensor = GetComponentInChildren<GroundSensor>();
    
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = _moveAction.ReadValue<Vector2>();
        rigidbody2D.linearVelocity = new Vector2(_moveDirection.x * movementSpeed, rigidbody2D.linearVelocity.y);


        if (_jumpAction.WasPressedThisFrame() && _sensor.isGrounded)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
            
        }
        _animator.SetBool("IsJumping", !_sensor.isGrounded);

        if (_moveDirection.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsWalking", true);
        }
        else if (_moveDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }
    
    }
}

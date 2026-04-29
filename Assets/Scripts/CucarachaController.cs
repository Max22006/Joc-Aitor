using UnityEngine;

public class CucarachaController : MonoBehaviour
{
    private Rigidbody2D _rbody;
    private Animator _animator;
    private BoxCollider2D _boxCollider;
    public float movementSpeed = 2f;
    public int direction = 1;
    private int _cucarachaHealth = 3;

    public SensorEnemy sensor;
    private Transform _playerPosition;
    public float detectionRange = 2;
    void Awake()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform; 

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(_playerPosition.position, transform.position);
        
        if (distanceToPlayer > detectionRange)
        {
           _rbody.linearVelocity = new Vector2(direction * movementSpeed, _rbody.linearVelocity.y);

        if (sensor.isCollision)
        {
           direction *= -1;
        }

        }
        else if(distanceToPlayer < detectionRange) 
        {
            FollowPlayer();
        }
        
    }
    void FollowPlayer()
    {
        Vector3 moveDirection = _playerPosition.position - transform.position;

        if (moveDirection.x < 0)
        {
            direction = -1;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(moveDirection.x > 0)
        {
            direction = 1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        _rbody.linearVelocity = new Vector2(direction * movementSpeed, _rbody.linearVelocity.y);

        
    }
    public void CucarachaDeath()
    {
        sensor.enabled = false;
        movementSpeed = 0;
       _boxCollider.enabled = false;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class CucarachaController : MonoBehaviour
{
    private Rigidbody2D _rbody;
    private Animator _animator;
    private BoxCollider2D _boxCollider;
    public float movementSpeed = 2f;
    public int direction = 1;
    public SensorEnemy sensor;
    private Transform _playerPosition;
    public float detectionRange = 2;

    private Slider _healthSlider;
    private int _cucarachaHealth = 3;
    void Awake()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform; 
        _healthSlider = GetComponentInChildren<Slider>();

    }
    void Start()
    {
        _healthSlider.maxValue = _cucarachaHealth;
        _healthSlider.value = _cucarachaHealth;
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
    public void TakeDamage(int damage, Vector3 impactDirection, float impactForce)
    {
        _cucarachaHealth -= damage;
        _healthSlider.value = _cucarachaHealth;

        GetComponent<Rigidbody2D>().AddForce(impactDirection * impactForce, ForceMode2D.Impulse);

        if (_cucarachaHealth <= 0)
        {
            CucarachaDeath();
        }

    }
    public void CucarachaDeath()
    {
        sensor.enabled = false;
        movementSpeed = 0;
       _boxCollider.enabled = false;
    }
    
}

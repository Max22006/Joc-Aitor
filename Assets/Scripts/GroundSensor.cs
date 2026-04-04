using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    PlayerController _playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Awake()
    {
        _playerScript = GetComponentInParent<PlayerController>();
    }
        public bool isGrounded;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            isGrounded = true;
        }
    }
    void OnTriggerStay2D2D(Collider2D collision)
    {
         if (collision.gameObject.layer == 7)
        {
            isGrounded = true;
        }
    }
    void OnTriggerExit2D2D(Collider2D collision)
    {
         if (collision.gameObject.layer == 7)
        {
            isGrounded = false;
        }
    }
}

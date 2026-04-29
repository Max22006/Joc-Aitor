using UnityEngine;

public class SensorEnemy : MonoBehaviour
{

    public bool isCollision;
    private Animator _animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _animator = GameObject.Find("Coco").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isCollision = true;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("IsDeath", true);
            Destroy(collision.gameObject, 1.2f);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isCollision = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isCollision = false;
        }
    }
}


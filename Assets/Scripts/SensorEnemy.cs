using UnityEngine;

public class SensorEnemy : MonoBehaviour
{

    public bool isCollision;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            Destroy(collision.gameObject, 1.5f);
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


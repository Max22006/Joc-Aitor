using UnityEngine;

public class Coin : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;

     private AudioSource _audioSource;
     public AudioClip coinSFX;
     private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameManager.AddCoins();

            _audioSource.PlayOneShot(coinSFX);

            Destroy(gameObject, 0.5f);
        }
    }

}

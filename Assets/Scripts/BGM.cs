using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gameMusic;

void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartBGM();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartBGM()
    {
        audioSource.loop = true;
        audioSource.clip =gameMusic;
        audioSource.Play();
    }
}

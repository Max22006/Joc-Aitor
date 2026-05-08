using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int collectedCoins = 0;
    public Text coinText;

    public GameObject victoryCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCoins()
    {
        collectedCoins++;
        coinText.text = collectedCoins.ToString();
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //LoadSceneAsync
    }
    
}

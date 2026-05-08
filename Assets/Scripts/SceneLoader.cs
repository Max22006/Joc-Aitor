using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //LoadSceneAsync
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();


        #else
        Application.Quit();
        #endif
    }
    
}

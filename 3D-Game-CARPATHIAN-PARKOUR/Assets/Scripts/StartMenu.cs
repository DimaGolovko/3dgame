using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void OpenOptions()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    public void LoadLevel()
    {
        var sceneId = gameObject.AddComponent<SaveManager>().LoadGame();
        
        if (!int.TryParse(sceneId, out var buildIndex)) return;

        SceneManager.LoadScene(buildIndex);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    public void Pause()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void Resume()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void Save()
    {
        gameObject.AddComponent<SaveManager>().SaveGame(SceneManager.GetActiveScene());
    }
    
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(1);
    }
}

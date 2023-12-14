using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void ToggleMute()
    {
        Debug.Log($"Audio = {AudioListener.volume}");
        AudioListener.volume = AudioListener.volume == 1 ? 0 : 1;
        Debug.Log($"Audio = {AudioListener.volume}");
    }
    
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

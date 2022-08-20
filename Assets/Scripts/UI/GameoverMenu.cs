using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameoverMenu : MonoBehaviour
{
    // Reloads the active scene
    public void Replay(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    // Loads the main menu (index 0)
    public void Quit(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-SceneManager.GetActiveScene().buildIndex);
    }
}

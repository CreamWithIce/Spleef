using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class MainMenu : MonoBehaviour
{

    public TMP_Text versionTxt;
    public void play(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quit(){
        Application.Quit();
    }

    void Start(){
        versionTxt.text = Application.version;

    }
}

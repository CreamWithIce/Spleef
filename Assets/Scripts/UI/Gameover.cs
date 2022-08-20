using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gameover : MonoBehaviour
{

    public GameObject gameOverScreen;
    public GameObject player1;
    public GameObject player2;
    public float deathHeight = -30f;

    public string player1Win;
    public string player2Win;
    public string drawText;
    public TMP_Text winText;

    // Update is called once per frame
    // Checks if player 1 or player 2 is lower than the death height and shows who won and if both are at the death height it is a draw
    void Update()
    {
        if(player1.transform.position.y <= deathHeight){
            Cursor.lockState = CursorLockMode.None;
            winText.text = player2Win;
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else if(player2.transform.position.y <= deathHeight){
            Cursor.lockState = CursorLockMode.None;
            winText.text = player1Win;
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
        if(player2.transform.position.y <= deathHeight && player1.transform.position.y <= deathHeight){
            Cursor.lockState = CursorLockMode.None;
            winText.text = drawText;
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

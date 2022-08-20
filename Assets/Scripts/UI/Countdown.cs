using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public float countdown=5f;
    int seconds;
    public TMP_Text txt;
    public GameObject CountdownScreen;
    public GameObject player1;
    public GameObject player2;
    float ogCountDown;

    // Sets the time scale to 1, resets the countdown and disables player movement
    void Start(){
        Time.timeScale = 1;
        player1.GetComponent<Movement>().enabled = false;
        player2.GetComponent<MovementController>().enabled = false;
        ogCountDown = countdown;
    }


    // Update is called once per frame

    // The countdown gets rounded up into an int then sent to the screen and once all the time has passed it will enable players movement and disable the countdown overlay
    void Update()
    {
        
        seconds = Mathf.RoundToInt(countdown);
        txt.text = seconds.ToString();
        if(countdown > -1f){
            countdown -= Time.deltaTime;
        }

        if(seconds == 0){
            txt.text = "GO";
        }

        else if(seconds == -1f){
            CountdownScreen.SetActive(false);
            countdown = ogCountDown;
            player1.GetComponent<Movement>().enabled = true;
            player2.GetComponent<MovementController>().enabled = true;
        }


    }
}

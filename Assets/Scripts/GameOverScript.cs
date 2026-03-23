using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public TextMeshPro scoreTimer;
    public int score;
    public double timer;
    
    //This script controls what happens on the Game Over screen
    //Currently, the only option is for the player to hit 'Space' and restart the game
    
    //Every frame, we check for player inputs
    void Update()
    {
        TimerScript.timerStop();
        timer = TimerScript.currentTime;
        score = PlayerScript.Score;

        scoreTimer.text = "Score: " + score + "\n" + "Time: " + timer.ToString("F2") + "\n" + "Died on: " + PlayerScript.currentScene;
    //If the player hit space. . .
    if (Input.GetKeyDown(KeyCode.Space))
        {
            //Then load the 'Example 3' scene
            SceneManager.LoadScene("Tutorial");
            TimerScript.currentTime = 0.0d;
            PlayerScript.Score = 0;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Object = System.Object;

public class PlayerScript : MonoBehaviour
{
    //These are the player's Variables, the raw info that defines them
    
    //The Rigidbody2D is a component that gives the player physics, and is what we use to move
    public Rigidbody2D RB;

    //TextMeshPro is a component that draws text on the screen.
    //We use this one to show our score.
    public TextMeshPro ScoreText;
    
    //This will control how fast the player moves
    public static float Speed = 5;
    
    //This is how many points we currently have
    public static int Score = 0;

    //Coin counter for next scene
    public int coinCount;

    public float speedBoost = Speed * 2;
    public bool boostOn;
    public bool cooldown;
    public double boostTimer;
    public double cooldownTimer;
    
    //Start automatically gets triggered once when the objects turns on/the game starts
    void Start()
    {   
        
        //Creates array of game objects tagged "Coin"
        GameObject[] coinObjects = GameObject.FindGameObjectsWithTag("Coin");
    
        //Number of "Coin" objects
        coinCount  = coinObjects.Length;

        boostOn = true;
        cooldown = false;
        boostTimer = 1.0d;
        cooldownTimer = 3.0d;
        
        //During setup we call UpdateScore to make sure our score text looks correct
        Score = 0;
        UpdateScore();
    }

    //Update is a lot like Start, but it automatically gets triggered once per frame
    //Most of an object's code will be called from Update--it controls things that happen in real time
    void Update()
    {  
        //The code below controls the character's movement
        //First we make a variable that we'll use to record how we want to move
        Vector2 vel = new Vector2(0,0);
        
        //If I hold the right arrow key, the player should move right. . .
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Speed;
        }
        //If I hold the left arrow, the player should move left. . .
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -Speed;
        }
        //If I hold the up arrow, the player should move up. . .
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vel.y = Speed;
        }
        //If I hold the down arrow, the player should move down. . .
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vel.y = -Speed;
        }
        
        //BOOST LOGIC BELOW"
        
        
        
        //If I hold the right arrow key, the player should move right and BOOST. . .
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift) && boostOn)
        {
            vel.x = speedBoost;
        }
        //If I hold the left arrow, the player should move left and BOOST. . .
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift) && boostOn)
        {
            vel.x = -speedBoost;
        }
        //If I hold the up arrow, the player should move up and BOOST. . .
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift) && boostOn)
        {
            vel.y = speedBoost;
        }
        //If I hold the down arrow, the player should move down and BOOST. . .
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift) && boostOn)
        {
            vel.y = -speedBoost;
        }
        
        //Finally, I take that variable and I feed it to the component in charge of movement
        RB.linearVelocity = vel;
    }

    //This gets called whenever you bump into another object, like a wall or coin.
    private void OnCollisionEnter2D(Collision2D other)
    {
        //This checks to see if the thing you bumped into had the Hazard tag
        //If it does...
        if (other.gameObject.CompareTag("Hazard"))
        {
            //Run your 'you lose' function!
            Die();
        }

        //This checks to see if the thing you bumped into has the CoinScript script on it
        CoinScript coin = other.gameObject.GetComponent<CoinScript>();

        //If it does, run the code block belows
        if (coin != null)
        {
            //Tell the coin that you bumped into them so they can self destruct or whatever
            coin.GetBumped();
            //Make your score variable go up by one. . .
            Score++;
            
            //Update number of coins
            coinCount -= 1;
            
            //And then update the game's score text
            
            UpdateScore();
            if (coinCount == 1) {
                SceneManager.LoadScene("Game Start");
            }
        }
    
    }

    //This function updates the game's score text to show how many points you have
    //Even if your 'score' variable goes up, if you don't update the text the player doesn't know
    public void UpdateScore()
    {
        ScoreText.text = "Score: " + Score;
    }

    //If this function is called, the player character dies. The game goes to a 'Game Over' screen.
    public void Die()
    {
        SceneManager.LoadScene("Game Over");
    }
    
}

using UnityEngine;


public class HazardScript : MonoBehaviour
{
    public Rigidbody2D RB = new Rigidbody2D();
    public Vector2 velocity = new Vector2(0.0f, 0.0f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   

        /*Vertical patrol path for hazards/lava below*/
        if (RB.linearVelocity.y >= 0.0f && RB.position.y >= 2.0f)
        { 
            velocity.x = 0.0f;
            velocity.y = -5.0f; //Moves down after hitting upper limit of patrol
        }

        if (RB.linearVelocity.y <= 0.0f && RB.position.y <= -2.0f)
        {
            velocity.x = 0.0f;
            velocity.y = 5.0F; //Moves up after hitting lower limit of patrol
        }

        RB.linearVelocity = velocity;



    }
}

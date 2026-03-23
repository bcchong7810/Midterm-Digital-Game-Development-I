using UnityEngine;


public class HazardScript : MonoBehaviour
{
    public Rigidbody2D VHRB = new Rigidbody2D();
    public Vector2 velocity = new Vector2(0.0f, 0.0f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   

        /*Vertical patrol path for hazards/lava below*/
        if (VHRB.linearVelocity.y >= 0.0f && VHRB.position.y >= 4.5f)
        { 
            velocity.x = 0.0f;
            velocity.y = -5.0f; //Moves down after hitting upper limit of patrol
        }

        if (VHRB.linearVelocity.y <= 0.0f && VHRB.position.y <= -4.5f)
        {
            velocity.x = 0.0f;
            velocity.y = 5.0F; //Moves up after hitting lower limit of patrol
        }

        VHRB.linearVelocity = velocity;



    }
}

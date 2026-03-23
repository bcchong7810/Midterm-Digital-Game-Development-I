using UnityEngine;

public class HorizontalHazardScript : MonoBehaviour
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
        
        if (RB.linearVelocity.x >= 0.0f && RB.position.x >= 4.5f)
        { 
            velocity.x = -5.0f;
            velocity.y = 0.0f; 
        }

        if (RB.linearVelocity.x <= 0.0f && RB.position.x <= -4.5f)
        {
            velocity.x = 5.0f;
            velocity.y = 0.0F; 
        }

        RB.linearVelocity = velocity;



    }
}

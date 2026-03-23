using UnityEngine;
using UnityEngine.Jobs;

public class HunterSeeker : MonoBehaviour
{
    public Rigidbody2D RB;
    public Rigidbody2D PLRB;
    public Vector2 velocity;
    public double speed = 2.0f;
    public Vector2 playerPosition;
    public Vector2 hunterSeekerPosition;
    public static float distance;
    public float aggro = 3.0f;
    public SpriteRenderer SR;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = PLRB.position;
        hunterSeekerPosition = RB.position;
        distance = Vector2.Distance(playerPosition, hunterSeekerPosition);
        
        if (distance <= aggro)
        {
            SR.color = Color.deepPink;
            if (playerPosition.x >= hunterSeekerPosition.x)
            {
                velocity.x = 1.5f;
            } else if (playerPosition.x <= hunterSeekerPosition.x)
            {
                velocity.x = -1.5f;
            }

            if (playerPosition.y >= hunterSeekerPosition.y)
            {
                velocity.y = 1.5f;
            } else if (playerPosition.y <= hunterSeekerPosition.y)
            {
                velocity.y = -1.5f;
            } 
        }
        else
        {   
            SR.color = new Color32(70, 0,0,255);
            velocity.x = 0.0f;
            velocity.y = 0.0f;
        }


        RB.linearVelocity = velocity;


    }
}
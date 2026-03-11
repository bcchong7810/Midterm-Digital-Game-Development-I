using UnityEngine;

public class VanishingWall : MonoBehaviour
{   
    public GameObject VW;
    public const double lifeTime = 0.0d; //Initialize before testing
    public const double deathTime = 0.0d; // Initialize before testing
    public double lifeTimer = lifeTime;
    public double deathTimer = 0.0d;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTimer > 0.0d)
        {
            lifeTimer -= Time.deltaTime;
        } else
        {
            Destroy(gameObject);
            deathTimer = deathTime;
        }

        if (deathTimer > 0.0d)
        {
            deathTimer -= Time.deltaTime;
        }
        else
        {
            lifeTimer = lifeTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(VW, VW.transform.position, Quaternion.identity); 
        }
        

    }
}

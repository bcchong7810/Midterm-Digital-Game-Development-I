using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class VanishingWall : MonoBehaviour
{   
    public GameObject VWprefab;
    public GameObject VWInstance;
    public bool lifeSwitch;
    public double resetTimer = 1.0d;
    public double timer;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = resetTimer;
        lifeSwitch = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0.0d && lifeSwitch)
        {
            timer += resetTimer;
            lifeSwitch = false;
            Destroy(VWInstance);
        }  
        
        if (timer > 0.0d && lifeSwitch)
        {
            timer -= Time.deltaTime;
        } 
        
        if (timer <= 0.0d && !lifeSwitch)
        {   
            timer += resetTimer;
            lifeSwitch = true;
            VWInstance = Instantiate(VWprefab , new Vector3(-3, 0, 0), Quaternion.identity);
        } 
        
        if (timer > 0.0d && !lifeSwitch)
        {
            timer -= Time.deltaTime;
        }
        
    }




    
    
}

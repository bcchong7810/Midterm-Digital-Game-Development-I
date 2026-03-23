using System.Timers;
using UnityEngine;
using TMPro;
using UnityEditor;

public class TroubleShootingTimer : MonoBehaviour
{
    public double timer;
    public double resetTimer = 5.0d;
    public bool lifeSwitch;
    public TextMeshPro lifeDeathTimerText;

    void Start()
    {
        timer = resetTimer;
        lifeSwitch = true;
        
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (timer <= 0.0d && lifeSwitch)
        {
            timer += resetTimer;
            lifeSwitch = false;
            Debug.Log("DESTROY TEST");
        }  
        
        if (timer > 0.0d && lifeSwitch)
        {
            timer -= Time.deltaTime;
            Debug.Log("Countdown1 TEST");
        } 
        
        if (timer <= 0.0d && !lifeSwitch)
        {
            Debug.Log("CREATE TEST");            
            timer += resetTimer;
            lifeSwitch = true;

        } 
        
        if (timer > 0.0d && !lifeSwitch)
        {
            timer -= Time.deltaTime;
            Debug.Log("Countdown2 TEST");
        }
        
    } 


}


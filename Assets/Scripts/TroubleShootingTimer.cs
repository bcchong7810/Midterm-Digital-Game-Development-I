using System.Timers;
using UnityEngine;
using TMPro;
using UnityEditor;

public class TroubleShootingTimer : MonoBehaviour
{
    public double timer = 0.0d;
    public bool lifeSwitch = true;
    public TextMeshPro lifeDeathTimerText; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0.0d && lifeSwitch)
        {
            timer += 5.0d;
            lifeSwitch = false;
        } else if (timer > 0.0d && lifeSwitch)
        {
            timer -= Time.deltaTime;
        } else if (timer <= 0.0d && !lifeSwitch)
        {
            timer += 5.0d;
            lifeSwitch = true;
        } else if (timer > 0.0d && !lifeSwitch)
        {
            timer -= Time.deltaTime;
        }

        lifeDeathTimerText.text = "Life and Death cycle: " + timer.ToString("F2") + "\n" + lifeSwitch.ToString();
        

    }
}


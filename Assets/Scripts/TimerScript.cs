using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    //Creates component to display text
    public TextMeshPro TimerText;
    public double currentTime = 0d;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   //Updates current time
        currentTime += Time.deltaTime;
        
        //Displays current time and sets format to two decimal points (a.bc)
        TimerText.text = "Time: " + currentTime.ToString("F2");
    }
    
}

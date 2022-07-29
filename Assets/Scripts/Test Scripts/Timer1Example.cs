using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer1Example : MonoBehaviour
{
    //delay between timers
    public float timerDelay = 1.0f;

    //hold the value of the next time the timer activates
    private float nextEventTime;

    // Start is called before the first frame update
    void Start()
    {
        //find the time the next event can happen after the first delay
        nextEventTime = Time.time + timerDelay;
    }

    // Update is called once per frame
    void Update()
    {
        //if the global event timer has passed the next event timer
        if (Time.time >= nextEventTime)
        {
            Debug.Log("It's Time!");
            nextEventTime = Time.time + timerDelay;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer2Example : MonoBehaviour
{
    //time between timers
    public float timerDelay = 1.0f;
    //value until the next timer
    private float timeUntilNextEvent;

    // Start is called before the first frame update
    void Start()
    {
        timeUntilNextEvent = timerDelay;
    }

    // Update is called once per frame
    void Update()
    {
        //reduce countdown
        timeUntilNextEvent -= Time.deltaTime;
        //check if countdown is complete
        if(timeUntilNextEvent <= 0)
        {
            Debug.Log("It's Time!");
            timeUntilNextEvent = timerDelay;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    //limit for the ammount of balls spawned
    public float limit;
    private float current;
    public float timerDelay = .5f;
    private float nextEventTime;

    
    // Start is called before the first frame update
    void Start()
    {
        nextEventTime = Time.time + timerDelay;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (current <= limit)
        {
            if(nextEventTime <= Time.time)
            {
                GameObject ball = Instantiate(Ball, transform.position , Quaternion.Euler(0,2,0));
                current++;
                nextEventTime = Time.time + timerDelay;

            }
            
        }

        
    }

    public GameObject Ball;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    //the distance moved each frame
    private float speed = .01F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the position of the object
        transform.position += Vector3.up * speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{   
    // Start is called before the first frame update
    public abstract void Start();

    //the outline for the move function, uses a vector for direction and a float to control speed.
    public abstract void Move(Vector3 direction, float speed);
    //the function to rotate the object
    public abstract void Rotate(float rSpeed);
}

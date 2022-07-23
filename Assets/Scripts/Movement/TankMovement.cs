using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : Movement
{
    //variable to hold the rigidbody component to alter the position later
    private Rigidbody rigid;
    // Start is called before the first frame update
    public override void Start()
    {
        // get the rigidbody component and all variables contained within
        rigid = GetComponent<Rigidbody>();
    }

    //function to move the tank
    public override void Move(Vector3 direction, float speed)
    {
        //create a vector to base our movement on, normalize(set all values to 1 without losing the distance), multiply speed to get the distance moved, and multiply time to have consistent speed
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
        //use the vector to move the tank through rigidbody
        rigid.MovePosition(rigid.position + moveVector);
    }

    //function to rotate the tank
    public override void Rotate(float rSpeed)
    {
        transform.Rotate(0f, rSpeed * Time.deltaTime, 0f);
    }
}

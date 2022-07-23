using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{

    // Start is called before the first frame update
    public override void Start()
    {
        //no change needed, so call the base function (base."function name")
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
         //no change needed, so call the base function (base."function name")
        base.Update();
    }

    //set up controls for moving the tank forwards, current code temporary
    public override void MoveForward()
    {
        Debug.Log("moving forward");
    }

    //set up controls for moving tank backwards, current code temporary
    public override void MoveBackward()
    {
        Debug.Log("moving back");
    }

    //set up controls for rotating the tank clockwise (to the right), current code temporary
    public override void RotateClockwise()
    {
        Debug.Log("turning clockwise");
    }

    //set up controls for rotating the tank counter clockwise (to the left), current code temporary
    public override void RotateCounterClockwise()
    {
        Debug.Log("turning counterclockwise");
    }

}

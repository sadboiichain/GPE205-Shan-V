using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller 
{

    //The KeyCodes for each input
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardsKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;


    // Start is called before the first frame update
    public override void Start()
    {   
        
        //run the parent class start function
        base.Start();

    }

    // Update is called once per frame
    public override void Update()
    {


        //run the parent class update function
        base.Update();

                //process the keyboard inputs every frame
        ProcessInputs();

    }

    public void ProcessInputs()
    {

        // detecting input for foreward movement (use Input.GetKey)
        if (Input.GetKey(moveForwardKey))
        {
            _pawn.MoveForward();
        }
        //detecting input for backward movement
        if (Input.GetKey(moveBackwardsKey))
        {
            _pawn.MoveBackward();
        }
        //detecting input for rotation clockwise
        if (Input.GetKey(rotateClockwiseKey))
        {
            _pawn.RotateClockwise();
        }
        //detecting input for rotation counter clockwise
        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            _pawn.RotateCounterClockwise();
        }

    }
}

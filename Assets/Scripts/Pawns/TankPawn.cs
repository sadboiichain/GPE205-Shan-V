using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    //timer variable
    private float timeUntilNextEvent;

    // Start is called before the first frame update
    public override void Start()
    {
        //no change needed, so call the base function (base."function name")
        base.Start();

        //set up timer
        timeUntilNextEvent = 0;
    }

    // Update is called once per frame
    public override void Update()
    {
         //no change needed, so call the base function (base."function name")
        base.Update();

        //timer code
        timeUntilNextEvent -= Time.deltaTime;

    }

    //set up controls for moving the tank forwards, current code temporary
    public override void MoveForward()
    {
        mover.Move(transform.forward, moveSpeed);
    }

    //set up controls for moving tank backwards, current code temporary
    public override void MoveBackward()
    {
        mover.Move(transform.forward, -moveSpeed);
    }

    //set up controls for rotating the tank clockwise (to the right), current code temporary
    public override void RotateClockwise()
    {
        mover.Rotate(turnSpeed);
    }

    //set up controls for rotating the tank counter clockwise (to the left), current code temporary
    public override void RotateCounterClockwise()
    {
        mover.Rotate(-turnSpeed); 
    }

    //set up the shooting function so the controller can call it
    public override void Shoot()
    {
        if (timeUntilNextEvent <= 0)
        {
            shooter.Shoot(bulletPrefab, fireForce, damageDone, lifespan);

            timeUntilNextEvent = fireRate;
        }

    }
}

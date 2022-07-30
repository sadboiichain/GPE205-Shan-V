using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    //variable to store the target object
    public GameObject target;
    //variable to store the time between state changes
    private float lastStateChangeTime;
    //variable for flee distance
    public float fleeDistance;
    //array of transforms for a system of waypoints
    public Transform[] waypoints;
    //how close before the waypoint is considered reached
    public float waypointStopDistance;
    //int for waypoint index
    private int currentWaypoint = 0;
    //enum for loop options
    public enum LoopingStates {IsLooping, IsNotLooping};
    public LoopingStates loopingStatus;

    //enum list for AI states
    public enum AIStates {Idle, Chase, Flee, Patrol, Attack, Scan, ReturnToPost};
    //enum for current state
    public AIStates currentState;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        //set AI State at the beginning
        ChangeState(AIStates.Idle);
    }

    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions();

        base.Update();
    }

    public void Shoot()
    {
        //tell the pawn to shoot
        pawn.Shoot();
    }

    //create the function MakeDecisions
    public void MakeDecisions()
    {
        switch (currentState)
        {
            case AIStates.Idle:
                //do work
                DoIdleState();
                //check for transitions
                if (IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIStates.Chase);
                }
                break;
            case AIStates.Chase:
                DoFleeState();
                if (!IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIStates.Idle);
                } 
                // else if (IsDistanceLessThan(target, 5))
                // {
                //     ChangeState(AIStates.Attack);
                // }
                break;
            case AIStates.Attack:
                DoAttackState();
                if(!IsDistanceLessThan(target, 5))
                {
                    ChangeState(AIStates.Chase);
                }
                break;
        }
    }

    //function to target the player after spawn
    public void TargetPlayerOne()
    {
        //if gameManager exists
        if(GameManager.instance != null)
        {
            //if the player array exists
            if (GameManager.instance.players != null)
            {
                //if there are players inside
                if(GameManager.instance.players.Count > 0)
                {
                    //then target the pawn of the first player controller
                    target = GameManager.instance.players[0].pawn.gameObject;
                }
            }
        }
    }

    //method to target the nearest player, can be edited to target nearest object of choice
    protected void TargetNearestTank()
    {
        //get a list of all pawn objects
        Pawn[] allTanks = FindObjectsOfType<Pawn>();

        //assume the closest tank is the first one
        Pawn closestTank = allTanks[0];
        float closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);

        //iterate through the array one at a time
        foreach (Pawn tank in allTanks)
        {
            //if this tank is closer that the closestTank
            if(Vector3.Distance(pawn.transform.position, tank.transform.position) <= closestTankDistance)
            {
                closestTank = tank;
                closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);
            }
        }
        //target the closest tank
        target = closestTank.gameObject;
    }

    //one method to change states
    protected bool IsDistanceLessThan(GameObject target, float distance)
    {
        if(Vector3.Distance(pawn.transform.position, target.transform.position) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //AI states: change state method
    public void ChangeState(AIStates newState)
    {
        //change the state
        currentState = newState;
        //save the time this change happened
        lastStateChangeTime = Time.time;
    }

    //AI states: idle
    protected void DoIdleState()
    {
        //do nothing
    }
    
    //AI State: chase
    protected void DoChaseState()
    {
        //seek the target
        Seek(target);
    }

    //AI Action: Seek
    public void Seek(GameObject target)
    {
        //rotate to the target
        pawn.RotateTowards(target.transform.position);
        //move forward
        pawn.MoveForward();
    }
    public void Seek(Vector3 targetPosition)
    {
        pawn.RotateTowards(targetPosition);
        pawn.MoveForward();
    }
    public void Seek(Transform targetTransform)
    {
        pawn.RotateTowards(targetTransform.position);
        pawn.MoveForward();
    }
    public void Seek(Pawn targetPawn)
    {
        pawn.RotateTowards(targetPawn.transform.position);
        pawn.MoveForward();
    }
    public void Seek(Controller control)
    {
        pawn.RotateTowards(control.pawn.transform.position);
        pawn.MoveForward();
    }

    //AI State: attack
    protected void DoAttackState()
    {
        pawn.moveSpeed = 3;
        //chase
        Seek(target);
        //shoot
        Shoot();
    }

    //AI State: Flee
    protected void DoFleeState()
    {
        Flee();
    }

    //AI Action: Flee
    protected void Flee()
    {
        //distance away from player
        float targetDistance = Vector3.Distance(target.transform.position, pawn.transform.position);
        //percentage of flee distance
        float percentageOfFleeDistance = targetDistance / fleeDistance;
        // inverse to provide proper flee logic
        float flippedPercentageOfFleeDistance = 1 - percentageOfFleeDistance;
        //clamp between 0 and 1, so the max is fleeDistance and the min is targetDistance
        percentageOfFleeDistance = Math.Clamp(percentageOfFleeDistance, 0, 1);
        flippedPercentageOfFleeDistance = Math.Clamp(percentageOfFleeDistance, 0, 1);

        //find the vector to our target
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        //find the vector away by multiplying -1
        Vector3 vectorAwayFromTarget = -vectorToTarget;
        //find the vector to travel to run away
        Vector3 fleeVector = vectorAwayFromTarget.normalized * fleeDistance;

        fleeDistance = fleeDistance * flippedPercentageOfFleeDistance;
        pawn.RotateTowards(fleeVector);
        pawn.MoveBackward();
    }

    //AI Action: Patrol
    protected void Patrol(){
        //if there are enough waypoints to move
        if(waypoints.Length > currentWaypoint)
        {
            //seek the waypoint
            Seek(waypoints[currentWaypoint]);
            //if close to the current waypoint...
            if(Vector3.Distance(pawn.transform.position, waypoints[currentWaypoint].position) < waypointStopDistance)
            {
                currentWaypoint++;
            }
        }
        else
        {
            restartPatrol();
        }
    }

    //function to restart the patrol
    protected void restartPatrol()
    {
        //set index to 0
        currentWaypoint = 0;
    }

}

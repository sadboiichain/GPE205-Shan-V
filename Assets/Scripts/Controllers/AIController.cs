using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    //variable to store the target object
    public GameObject target;
    //variable to store the time between state changes
    protected float lastStateChangeTime;
    //variable for flee distance
    public float fleeDistance;
    //array of transforms for a system of waypoints
    public Transform[] waypoints;
    //how close before the waypoint is considered reached
    public float waypointStopDistance;
    //int for waypoint index
    protected int currentWaypoint = 0;
    //enum for loop options
    public enum LoopingStates {IsLooping, IsNotLooping};
    public LoopingStates loopingStatus;

    //enum list for AI states
    public enum AIStates {Idle, Chase, Flee, Patrol, Attack, Scan, ReturnToPost};
    //enum for current state
    public AIStates currentState;

    //variable for hearingDistance, how far the ai can "hear" an object
    public float hearingDistance;
    //variable for field of view, how far the ai can "see" an object
    public float fieldOfView;

    //timer varaible to reduce the checks done by ai
    public float aiSenseDelay;
    //variable to know when to let the ai check next;
    private float nextAIScan;
    //delay between states
    protected float stateDelay;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        //set the timer to adjust after the delay
        nextAIScan = Time.time + aiSenseDelay;


        TargetPlayerOne();
        // TargetNearestTank();

        //set AI State at the beginning
        ChangeState(AIStates.Patrol);

        //if gameManager exists
        if(GameManager.instance != null)
        {   //if AIlist exists
            if(GameManager.instance.AIList != null)
            {   //add to list
                GameManager.instance.AIList.Add(this);
            }
        }

    }

    // Update is called once per frame
    public override void Update()
    {
        // MakeDecisions();

        base.Update();
    
        if(nextAIScan <= Time.time)
        {   
            // if(target == null)
            // {
            //     TargetNearestTank();
            // }
            //check if the ai can hear target
            CanHear(target);
            //check if the ai can see the target
            CanSee(target);
            //reset the timer
            nextAIScan = Time.time + aiSenseDelay;
        }
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
                if (CanHear(target))
                {
                    ChangeState(AIStates.Scan);
                }
                break;
            case AIStates.Chase:
                DoChaseState();
                stateDelay = 10f;
                if (Time.time >= lastStateChangeTime+stateDelay)
                {
                    ChangeState(AIStates.Scan);
                } 
                else if (IsDistanceLessThan(target, 5))
                {
                    ChangeState(AIStates.Attack);
                }
                break;
            case AIStates.Attack:
                DoAttackState();
                if(!IsDistanceLessThan(target, 5))
                {
                    ChangeState(AIStates.Chase);
                }
                break;
            case AIStates.Flee:
                DoFleeState();
                if(!IsDistanceLessThan(target, 15))
                {
                    ChangeState(AIStates.Idle);
                }
                break;
            case AIStates.Patrol:
                doPatrolState();
                if(CanHear(target))
                {
                    ChangeState(AIStates.Scan);
                }
                break;
            case AIStates.Scan:
                doScanState();
                stateDelay = 5f;
                if(CanSee(target))
                {
                    
                    ChangeState(AIStates.Chase);
                }
                else if(Time.time >= lastStateChangeTime+stateDelay)
                {
                    ChangeState(AIStates.Patrol);
                }
                break;
            case AIStates.ReturnToPost:
                doReturnState();
                if(CanHear(target))
                {
                    ChangeState(AIStates.Scan);
                }
                else if(IsDistanceLessThan(waypoints[0].gameObject, waypointStopDistance))
                {
                    ChangeState(AIStates.Patrol);
                }
                break;
        }
    }

    //function to target the player after spawn
    protected void TargetPlayerOne(){
        if(GameManager.instance != null)
        {
            if(GameManager.instance.playerControllerList != null)
            {
                if(GameManager.instance.playerControllerList.Count > 0)
                {
                    if(GameManager.instance.playerControllerList[0].pawn != null)
                    {
                        target = GameManager.instance.playerControllerList[0].pawn.gameObject;
                    }
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

    protected bool isHasTarget()
    {
        return (target != null);
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
        if(!IsDistanceLessThan(target, 2)){
            Seek(target);
        }

        
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

    //AI State: Patrol
    protected void doPatrolState()
    {
        Patrol();
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

    //AI State: Scan
    protected void doScanState()
    {
        Scan();
    }

    //AI Action: Scan
    protected void Scan()
    {
        pawn.RotateTowards(target.transform.position);
    }

    //AI State: Return
    public void doReturnState()
    {
        Seek(waypoints[currentWaypoint]);
    }

    public void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            if(GameManager.instance.AIList != null)
            {
                GameManager.instance.AIList.Remove(this);
            }
        }
    }

        //boolean to "listen" for the noiseMaker script
    public bool CanHear(GameObject target)
    {
        //get the targets noiseMaker
        if(target == null)
        {
            target = GameManager.instance.AIList[0].gameObject;
            return false;
        }
        NoiseMaker noise = target.GetComponent<NoiseMaker>();
        //if target does not have a noisemaker/can not make noise
        if(noise == null)
        {
            return false;
        }
        //if there is no noise to be heard/ volume at 0
        if(noise.volumeDistance <= 0)
        {
            return false;
        }

        //if the target is making noise, add volumeDistance to the hearingDistance in the ai
        float totalDistance = noise.volumeDistance + hearingDistance;
        //if the distance is between the max distance(totalDistance) and the ai 
        if(Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool CanSee(GameObject target)
    {
        if(target == null)
        {
            return false;
        }
        //find the vector from the agent(tank?) to the target
        Vector3 agentToTargetVector = target.transform.position - pawn.transform.position;
        //creat a ray object to easily call later (vector for location of ray start, vector for ray angle)
        Ray sight = new Ray(pawn.transform.position, agentToTargetVector);
        //store the info of what was hit by the raycast
        RaycastHit hit;

        //find angle between the directon our agent is facing (forward in local space) and the vector to the target
        float angleToTarget = Vector3.Angle(agentToTargetVector, pawn.transform.forward * pawn.maxViewDistance);

        Physics.Raycast(sight, out hit, pawn.maxViewDistance);

        //if this angle is less than our field of view
        if (angleToTarget < fieldOfView)
        {              
            if(IsDistanceLessThan(target, pawn.maxViewDistance)){
                if(hit.collider.gameObject == target)
                {
                    return true;
                }
                else{
                    return false;
                }
            }
            else   
            {
                return false;
            }
            
        }
        else
        {
            return false;
        }

    }

}

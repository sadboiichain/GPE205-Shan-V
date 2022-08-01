using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coward : AIController
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        currentWaypoint = 0;
        ChangeState(AIStates.Patrol);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        TargetNearestTank();
        MakeDecisions();
    }

    //create the function MakeDecisions
    public new void MakeDecisions()
    {
        switch (currentState)
        {
            case AIStates.Attack:
                DoAttackState();
                if(!IsDistanceLessThan(target, 5))
                {
                    ChangeState(AIStates.Flee);
                }
                break;
            case AIStates.Flee:
                DoFleeState();
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
                Debug.Log(CanSee(target));
                if(CanSee(target))
                {
                    
                    ChangeState(AIStates.Flee);
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
                else if(IsDistanceLessThan(waypoints[currentWaypoint].gameObject, waypointStopDistance))
                {
                    ChangeState(AIStates.Patrol);
                }
                break;
        }
    }

    public new void DoAttackState()
    {
        pawn.moveSpeed = 7;
        
        
        if(!IsDistanceLessThan(target, 2)){
            Flee();
        }
        
        //shoot
        Shoot();
    }
}

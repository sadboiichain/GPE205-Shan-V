using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agressive : AIController
{
    
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        currentWaypoint = 2;
        ChangeState(AIStates.Patrol);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        TargetPlayerOne();
        MakeDecisions();
    }

    public new void MakeDecisions(){
        switch (currentState)
        {
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
                else if(IsDistanceLessThan(waypoints[currentWaypoint].gameObject, waypointStopDistance))
                {
                    ChangeState(AIStates.Patrol);
                }
                break;
        }
    }

    public new void DoAttackState()
    {
        pawn.moveSpeed = 4;
        if(target == null)
        {
            ChangeState(AIStates.Idle);
        }

        if(!IsDistanceLessThan(target, 2)){
            Seek(target);
        }
        
        //shoot
        Shoot();
    }
}

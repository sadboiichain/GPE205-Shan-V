using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : AIController
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        pawn.moveSpeed -= 2;
        currentWaypoint = 2;
        ChangeState(AIStates.Idle);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        MakeDecisions();
    }

    public new void MakeDecisions()
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
            case AIStates.Scan:
                doScanState();
                stateDelay = 5f;
                if(target == null)
                {
                    ChangeState(AIStates.Idle);
                }
                if(CanSee(target))
                {
                    
                    ChangeState(AIStates.Chase);
                }
                else if(Time.time >= lastStateChangeTime+stateDelay)
                {
                    ChangeState(AIStates.Idle);
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
                    ChangeState(AIStates.Idle);
                }
                break;
        }
    }
}

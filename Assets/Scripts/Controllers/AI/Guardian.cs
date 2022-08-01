using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : AIController
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
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
                DoIdleState();
                if(CanHear(target))
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
                stateDelay = 10f;
                Debug.Log(CanSee(target));
                if(CanSee(target))
                {
                    
                    ChangeState(AIStates.Chase);
                }
                else if(Time.time >= lastStateChangeTime+stateDelay)
                {
                    ChangeState(AIStates.ReturnToPost);
                }
                break;
            case AIStates.ReturnToPost:
                doReturnState();
                if(CanHear(target))
                {
                    ChangeState(AIStates.Scan);
                }
                else if(IsDistanceLessThan(waypoints[3].gameObject, waypointStopDistance))
                {
                    ChangeState(AIStates.Idle);
                }
                break;
        }
    }
}

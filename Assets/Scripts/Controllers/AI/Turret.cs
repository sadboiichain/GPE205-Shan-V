using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : AIController
{
    
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        currentWaypoint = 2;
        ChangeState(AIStates.Idle);
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
            case AIStates.Attack:
                DoAttackState();
                stateDelay = 5f;
                if(Time.time >= lastStateChangeTime+stateDelay)
                {
                    ChangeState(AIStates.Scan);
                }
                break;
            case AIStates.Scan:
                doScanState();
                stateDelay = 5f;
                if(CanSee(target))
                {
                    
                    ChangeState(AIStates.Attack);
                }
                else if(Time.time >= lastStateChangeTime+stateDelay)
                {
                    ChangeState(AIStates.Idle);
                }
                break;
            case AIStates.Idle:
                if(CanHear(target))
                {
                    ChangeState(AIStates.Scan);
                }
                break;
        }
    }

    public new void DoAttackState()
    {
        pawn.moveSpeed = 0;
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

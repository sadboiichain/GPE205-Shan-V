using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    //get the movement class so objects can move
    public Movement mover;
    
    //keep track of the controller of the pawn
    public Controller control;

    //variable for move speed
    public float moveSpeed;
    //variable for turn speed
    public float turnSpeed;
    
public void test(){
    Debug.Log("test complete");
}

    //abstract variables so each class can adjust
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();

    // Start is called before the first frame update
    public virtual void Start() 
    {
        //access the methods in movement
        mover = GetComponent<Movement>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
    }
}

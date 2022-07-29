using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller 
{

    //The KeyCodes for movement inputs
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardsKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;

    //keycode for shooting input
    public KeyCode shootKey;


    // Start is called before the first frame update
    public override void Start()
    {   
        //for the gameManager to add/check the list of players
        //if there is a game manager
        if(GameManager.instance != null)
        {
            //if the player list exists
            if(GameManager.instance.players != null)
            {   //add to the player list
                GameManager.instance.players.Add(this);
            }
        }

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
            pawn.MoveForward();
        }
        //detecting input for backward movement
        if (Input.GetKey(moveBackwardsKey))
        {
            pawn.MoveBackward();
        }
        //detecting input for rotation clockwise
        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }
        //detecting input for rotation counter clockwise
        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }
        //detect input for shooting
        if (Input.GetKey(shootKey))
        {
            
            pawn.Shoot();


        }

    }

    //remove from game manager if it exists
    public void OnDestroy()
    {
        if(GameManager.instance != null)
        {
            if(GameManager.instance.players != null)
            {   //remove from player list
                GameManager.instance.players.Remove(this);
            }
        }
    }
}

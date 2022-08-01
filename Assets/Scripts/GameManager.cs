using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    //create the singleton gameManager
    public static GameManager instance;

    //used to set the location of the player spawn
    public Transform playerSpawnTransform;

    //list of playerControllers
    public List<PlayerController> playerControllerList;
    //list of controllers
    public List<Controller> controllerList;
    //List of pawns
    public List<Pawn> pawnList;
    //list of aiControllers
    public List<AIController> AIList;


    //Use Awake(); to do smething when the object is created, before Start(); can run
    private void Awake()
    {
        // check for other gameManagers
        if (instance == null)
        {
            //none found, this is now the gameManager
            instance = this;
        } 
        else//other manager is found
        {
            //destroy this one to remove conflicts
            Destroy(gameObject);
        }

        //spawn the player before the start funtion
        SpawnPlayer();
    }


    public void SpawnPlayer()
    {
        //spawn playerController at origin with no rotation
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //spawn the pawn and connect it to the controller
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;

       //get the playerController component and the pawn component
       Controller newController = newPlayerObj.GetComponent<Controller>();
       Pawn newPawn = newPawnObj.GetComponent<Pawn>();

       //connect the new objects
       newController.pawn = newPawn;

    }

    //prefabs 
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    //create the singleton gameManager
    public static GameManager instance;

    //list of playerControllers
    public List<PlayerController> playerControllerList;
    //list of controllers
    public List<Controller> controllerList;
    //List of pawns
    public List<Pawn> pawnList;
    //list of aiControllers
    public List<AIController> AIList;
    //limit for pickups
    public float pickupLimit;
    public List<GameObject> powerList;
    public PawnSpawnPoint[] spawn; 
    private Transform playerSpawnTransform;

    public List<AIController> spawnList;
    public List<Pawn> aiSpawnList;


    //Use Awake(); to do smething when the object is created, before Start(); can run
    private void Awake()
    {
        powerList = new List<GameObject>();
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
    }

    private void Start()
    {
        spawn = FindObjectsOfType<PawnSpawnPoint>();
        setPlayerSpawn();
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

    public void setPlayerSpawn()
    {   
        int temp = Random.Range(0,spawn.Length);
        playerSpawnTransform = spawn[temp].GetComponent<Transform>();
        Destroy(spawn[temp]);
    }

    public void SpawnAI(GameObject AIPrefab, GameObject AIControlPrefab)
    {


    }

    //prefabs 
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;
}

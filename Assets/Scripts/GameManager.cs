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

    public List<GameObject> AIControllerSpawn;
    public List<GameObject> AIPawnSpawn;

    private Transform AISpawnTransform;


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
        SpawnAI(AIPawnSpawn[0], AIControllerSpawn[0]);
        SpawnAI(AIPawnSpawn[1], AIControllerSpawn[1]);
        SpawnAI(AIPawnSpawn[2], AIControllerSpawn[2]);
        SpawnAI(AIPawnSpawn[3], AIControllerSpawn[3]);
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

    public void SpawnAI(GameObject AIPrefab, GameObject AIControlPrefab)//2 ideas: run this 4 times, once with each ai; or run a for/foreach loop to spawn each one without calling 4 times
    {
        //spawn AIcontroller at origin with no rotation
        GameObject newAICont = Instantiate(AIControlPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //spawn AiPrefab at a random spawn
        setAISpawn();
        GameObject newAIPawn = Instantiate(AIPrefab, AISpawnTransform.position, Quaternion.identity) as GameObject;

        AIController newController = newAICont.GetComponent<AIController>();
        Pawn newAI = newAIPawn.GetComponent<Pawn>();

    }

    public void setAISpawn()
    {   
        int temp = Random.Range(0,spawn.Length);
        AISpawnTransform = spawn[temp].GetComponent<Transform>();
        Destroy(spawn[temp]);
    }

    //prefabs 
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;
}

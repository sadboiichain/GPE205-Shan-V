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
    private Transform LastSpawn;
    private Transform LastAISpawn;

    private Transform[] waypoints;



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
        ActivateTitleScreen();

        // spawn = FindObjectsOfType<PawnSpawnPoint>();
        // SpawnPlayer();
        // SpawnAI(AIPawnSpawn[0], AIControllerSpawn[0]);   //aggressive
        // SpawnAI(AIPawnSpawn[1], AIControllerSpawn[1]);   //coward
        // SpawnAI(AIPawnSpawn[2], AIControllerSpawn[2]);
        // SpawnAI(AIPawnSpawn[3], AIControllerSpawn[3]);

    }

    private void Update()
    {
        ProcessInputs();
    }


    public void SpawnPlayer()
    {
        setPlayerSpawn();
        //spawn playerController at origin with no rotation
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //spawn the pawn and connect it to the controller
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;

       //get the playerController component and the pawn component
       PlayerController newController = newPlayerObj.GetComponent<PlayerController>();
       Pawn newPawn = newPawnObj.GetComponent<Pawn>();

       //connect the new objects
       newController.pawn = newPawn;
       newPawn.control = newController;

       newController.Score = 0;

    }

    public void RespawnPlayer(Pawn toRespawn)
    {
        setPlayerSpawn();
        if(playerSpawnTransform == LastSpawn)
        {
            setPlayerSpawn();
        }
        toRespawn.transform.position = playerSpawnTransform.position;
        toRespawn.LifeLost();
        toRespawn.GetComponent<Health>().currentHealth = toRespawn.GetComponent<Health>().maxHealth;
    }

    public void setPlayerSpawn()
    {   
        int temp = Random.Range(0,spawn.Length);
        playerSpawnTransform = spawn[temp].GetComponent<Transform>();
        LastSpawn = spawn[temp].GetComponent<Transform>();
    }

    public void SpawnAI(GameObject AIPrefab, GameObject AIControlPrefab)//2 ideas: run this 4 times, once with each ai; or run a for/foreach loop to spawn each one without calling 4 times
    {
        //spawn AIcontroller at origin with no rotation
        GameObject newAICont = Instantiate(AIControlPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //spawn AiPrefab at a random spawn
        setAISpawn();
        setAISpawn();
        if(AISpawnTransform == playerSpawnTransform || AISpawnTransform == LastAISpawn)
        {
            setAISpawn();
        }

        GameObject newAIPawn = Instantiate(AIPrefab, AISpawnTransform.position, Quaternion.identity) as GameObject;

        AIController newController = newAICont.GetComponent<AIController>();
        Pawn newAI = newAIPawn.GetComponent<Pawn>();

        newController.pawn = newAI;
        newAI.control = newController;

        Room newRoom = AISpawnTransform.parent.GetComponent<Room>();
        newController.waypoints = newRoom.patrolPoints;

    }

    public void setAISpawn()
    {   
        int temp = Random.Range(0,spawn.Length);
        if(LastAISpawn == null)
        {
            LastAISpawn = playerSpawnTransform;
        }
        else
        {
            LastAISpawn = AISpawnTransform;
        }
        AISpawnTransform = spawn[temp].GetComponent<Transform>();
        
    }

    //prefabs 
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;


    //Game States
    public GameObject TitleScreenStateObject;
    public GameObject MainMenuStateObject;
    public GameObject OptionsStateObject;
    public GameObject CreditsStateObject;
    public GameObject GameplayStateObject;
    public GameObject GameOverStateObject;

    private void DeactivateAllStates()
    {
        TitleScreenStateObject.SetActive(false);
        MainMenuStateObject.SetActive(false);
        OptionsStateObject.SetActive(false);
        CreditsStateObject.SetActive(false);
        GameplayStateObject.SetActive(false);
        GameOverStateObject.SetActive(false);
    }

    public void ActivateTitleScreen()
    {
        //deactivate all states to refresh
        DeactivateAllStates();
        //activate the title screen
        TitleScreenStateObject.SetActive(true);
        //(fill in later with whatever the title screen does)
        Debug.Log("title");
    }

    public void ActivateMainMenu()
    {
        //deactivate all states to refresh
        DeactivateAllStates();
        //activate the Main Menu
        MainMenuStateObject.SetActive(true);
        //(fill in later with whatever the Main Menu does)
        Debug.Log("menu");
    }

    public void ActivateOptionsMenu()
    {
        //deactivate all states to refresh
        DeactivateAllStates();
        //activate the options menu
        OptionsStateObject.SetActive(true);
        //(fill in later with whatever the options menu does)
        Debug.Log("options");
    }

    public void ActivateCreditsMenu()
    {
        //deactivate all states to refresh
        DeactivateAllStates();
        //activate the Credits screen
        CreditsStateObject.SetActive(true);
        //(fill in later with whatever the credits does)
        Debug.Log("credits");
    }

    public void ActivateGameplay()
    {
        //deactivate all states to refresh
        DeactivateAllStates();
        //activate the Gameplay
        GameplayStateObject.SetActive(true);
        //(fill in later with whatever the gameplay state does)
        Debug.Log("gamePlay");
    }

    public void ActivateGameOverScreen()
    {
        //deactivate all states to refresh
        DeactivateAllStates();
        //activate the Game Over
        GameOverStateObject.SetActive(true);
        //(fill in later with whatever the game over does)
        Debug.Log("gameOver");
    }

    //keycodes to test the transitions between scenes, will delete later
    public KeyCode title;
    public KeyCode main;
    public KeyCode options;
    public KeyCode credits;
    public KeyCode gamePlay;
    public KeyCode gameOver;

    public void ProcessInputs()
    {

        // detecting input for title screen
        if (Input.GetKey(title))
        {
            ActivateTitleScreen();
        }
        // detecting input for main menu
        if (Input.GetKey(main))
        {
            ActivateMainMenu();
        }
        // detecting input for options
        if (Input.GetKey(options))
        {
            ActivateOptionsMenu();
        }
        // detecting input for credits
        if (Input.GetKey(credits))
        {
            ActivateCreditsMenu();
        }
        // detecting input for gamePlay
        if (Input.GetKey(gamePlay))
        {
            ActivateGameplay();
        }
        // detecting input for gameOver
        if (Input.GetKey(gameOver))
        {
            ActivateGameOverScreen();
        }

    }

}

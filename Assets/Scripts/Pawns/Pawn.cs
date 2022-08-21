using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    //get the movement class so objects can move
    public Movement mover;
    
    //keep track of the controller of the pawn
    public Controller control;

    //get the shooting class, since our pawns can shoot
    public Shooter shooter;
    
    public NoiseMaker noise;

    //variable for move speed
    public float moveSpeed;
    //variable for turn speed
    public float turnSpeed;

    //variable for bullet prefab
    public GameObject bulletPrefab;
    //variable for fireForce(speed of bullet?)
    public float fireForce;
    //variable for damage
    public float damageDone;
    //variable for how long the bullet lives if no collision happens
    public float lifespan;

    //variable for fire rate(time between shots)
    public float fireRate;

    //variable for view distance(how far our tanks can "see")
    public float maxViewDistance;

    public float lives;

    public UILives Life;
    public UIScore scoreCount;

    //abstract functions so each class can adjust
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void StrafeRight();
    public abstract void StrafeLeft();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();

    //abstract function to shoot
    public abstract void Shoot();

    //abstract function to turn towards a target object
    public abstract void RotateTowards(Vector3 targetPosition);

    // Start is called before the first frame update
    public virtual void Start() 
    {
        //access the methods in movement
        mover = GetComponent<Movement>();
        //access the methods in shooter
        shooter = GetComponent<Shooter>();
        //access the information in noiseMaker
        noise = GetComponent<NoiseMaker>();

        //flip the fireRate from time between shots to shots per second
        // fireRate = 1 / fireRate;

        //check for gameManager
        if(GameManager.instance != null)
        {   //check for pawnList
            if(GameManager.instance.pawnList != null)
            {   //add to panwList
                GameManager.instance.pawnList.Add(this);
            }
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
    }

    public void OnDestroy()
    {
        if(GameManager.instance != null)
        {
            if(GameManager.instance.pawnList != null)
            {
                GameManager.instance.pawnList.Remove(this);
            }
        }
        Destroy(control.gameObject);
        //play the death audio
        GameManager.instance.manager.death.Playdeath();
    }

    public void LifeLost()
    {
        lives--;
        Life.UpdateLives(lives);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    //variable to hold the pawn class
    public Pawn pawn;

    //score variable
    public float Score;



    // Start is called before the first frame update
    public virtual void Start()
    { 
        
        //access the information in pawns
        pawn = pawn.GetComponent<Pawn>();

        //if gameManager exists
        if(GameManager.instance != null)
        {   //if controllerList exists
            if(GameManager.instance.controllerList != null)
            {   //add to controllerList
                GameManager.instance.controllerList.Add(this);
            }
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    private void OnDestroy()
    {
        if(GameManager.instance != null)
        {
             if(GameManager.instance.controllerList != null)
             {
                GameManager.instance.controllerList.Remove(this);
             }
        }
    }

        public void AddToScore(float toAdd)
    {
        Score += toAdd;
        if(pawn.scoreCount != null)
        {
            pawn.scoreCount.UpdateScore(Score);
            if(Score == 400)
            {
                GameManager.instance.ActivateWinnerScreen();
            }
            if(GameManager.instance.isMulti == true && Score == 500)
            {
                GameManager.instance.ActivateWinnerScreen();
            }
        }
    }
    
}

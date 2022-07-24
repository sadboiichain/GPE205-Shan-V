using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Use Awake(); to do smething when the object is created, before Start(); can run
    private void Awake()
    {
        //check for other gameManagers
        // if (instance == null)
        // {
        //     //none found, this is now the gameManager
        //     instance = this;
        // } 
        // else//other manager is found
        // {
        //     //destroy this one to remove conflicts
        //     Destroy(gameObject);
        // }
        
    }

}

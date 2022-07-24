using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    //variable to hold the pawn class
    public Pawn _pawn;

    // Start is called before the first frame update
    public virtual void Start()
    { 
        
        //access the information in pawns
        _pawn = _pawn.GetComponent<Pawn>();
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

}

//import from unity libraries, and add pre-written commands
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestExample : MonoBehaviour
{
    //a string for the game to output
    public string theText = "Hello World";

    //some fun testing 
    string startUp = "The Beginning...";
    int frameCount;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log(startUp);
    }

    // Update is called once per frame
    private void Update()
    {
        //Write the value store in the variable "theText" to the console window (print the text into the console)
        // Debug.Log(theText);
        Debug.Log(frameCount++);
    }
}

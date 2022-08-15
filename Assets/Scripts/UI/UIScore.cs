using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public Text scoreDisplay;
    
    public void UpdateScore(float scoreUpdate)
    {
        scoreDisplay.text = "Score = " + scoreUpdate;
    }
}

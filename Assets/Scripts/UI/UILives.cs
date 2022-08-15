using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILives : MonoBehaviour
{
    public Text LifeCount;

    public void UpdateLives(float life)
    {
        LifeCount.text = "Lives = " + life;
    }
}

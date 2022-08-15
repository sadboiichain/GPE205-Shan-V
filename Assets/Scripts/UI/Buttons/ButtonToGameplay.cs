using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToGameplay : MonoBehaviour
{
    public void changeToGameplay()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.ActivateGameplay();
        }
    }
}

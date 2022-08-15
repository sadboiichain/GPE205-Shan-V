using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToMain : MonoBehaviour
{
    public void changeToMenu()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.ActivateMainMenu();
        }
    }
}

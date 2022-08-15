using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToCredits : MonoBehaviour
{
    public void changeToCredits()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.ActivateCreditsMenu();
        }
    }
}

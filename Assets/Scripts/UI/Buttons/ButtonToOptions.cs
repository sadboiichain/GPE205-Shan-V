using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToOptions : MonoBehaviour
{
    public void changeToOptions()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.ActivateOptionsMenu();
        }
    }
}

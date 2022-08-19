using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiToggle : MonoBehaviour
{
    public Toggle multiToggle;

    public void updateMulti(bool toggle)
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.setMulti(toggle);
        }
    }
}

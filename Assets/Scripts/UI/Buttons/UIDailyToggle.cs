using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDailyToggle : MonoBehaviour
{
    public Toggle Daily;

    public MapGenerator map;

    public void UpdateDaily(bool toggle)
    {
        map.ChangeDaily(toggle);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRandomToggle : MonoBehaviour
{
    public Toggle Random;

    public MapGenerator map;

    public void UpdateRandom(bool toggle)
    {
        map.ChangeRandom(toggle);
    }
}

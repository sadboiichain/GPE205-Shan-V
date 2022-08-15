using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISeedInput : MonoBehaviour
{
    public InputField seedInput;

    public MapGenerator map;

    
    

    public void updateSeed(string seed)
    {
        int seedToBe = System.Convert.ToInt32(seed);
        map.setSeed(seedToBe);
        UnityEngine.Debug.Log(map.mapSeed);
    }
}

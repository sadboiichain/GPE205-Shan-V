using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public Image HealthImage;

    public void UpdateHealth(float currHealth, float maxHealth)
    {
        //set fill
        HealthImage.fillAmount = currHealth / maxHealth;
        

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    private static Image HealthBarImage;
 
    public static void SetStamina(float value)
    {
        HealthBarImage.fillAmount = value;

    }
    public static void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }
 
    private void Start()
    {
        HealthBarImage = GetComponent<Image>();
        SetHealthBarColor(Color.yellow);
    }
}

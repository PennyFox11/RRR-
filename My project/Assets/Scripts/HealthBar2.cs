//Title: How to make a HEALTH BAR in Unity!
//Author: Brackeys
//Date: 9 February 2020
//Code version: Unity 2019.3.0f6
//Availability: https://www.youtube.com/watch?v=BLfNP4Sc_iA

using UnityEngine;
using UnityEngine.UI; //namespace to enable use of UI components

public class HealthBar2 : MonoBehaviour
{

    public Slider slider; //create slider variable

    public void SetMaxHealth(int health) //adjust health slider by max health
    {
        slider.maxValue = health;
        slider.value = health; 
    }

    public void SetHealth(int health) //adjust health slider by current health
    {
        slider.value = health; 
    }
}

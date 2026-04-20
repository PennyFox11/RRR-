//Title: How to make a HEALTH BAR in Unity!
//Author: Brackeys
//Date: 9 February 2020
//Code version: Unity 2019.3.0f6
//Availability: https://www.youtube.com/watch?v=BLfNP4Sc_iA

using UnityEngine;
using UnityEngine.UI; //use the correct namespace

public class HealthBar : MonoBehaviour
{

    public Slider slider; //variable that stores the slider

    public void SetMaxHealth(int health) //set the max value automatically (no need to adjust in inspector every time)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health) //set the health value on the health bar slider
    {
        slider.value = health;
    }

}

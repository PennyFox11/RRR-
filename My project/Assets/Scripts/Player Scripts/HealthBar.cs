//Title: How to make a HEALTH VAR in Unity!
//Author: Brackeys
//Date: 9 February 2020
//Availability: https://www.youtube.com/watch?v=BLfNP4Sc_iA
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

}

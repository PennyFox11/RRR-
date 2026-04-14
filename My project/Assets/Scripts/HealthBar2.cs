//https://www.youtube.com/watch?v=BLfNP4Sc_iA
using UnityEngine;
using UnityEngine.UI;

public class HealthBar2 : MonoBehaviour
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

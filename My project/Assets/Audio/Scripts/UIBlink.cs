using UnityEngine;
using UnityEngine.UI;
//Title: Unity Tutorial: How To Make Characters Blink on Damage - URP Sprite Shader
//Author: PitilT
//Date: 1 January 2026
//Code version: Unity 6000.2.8f1
//Availability: https://www.youtube.com/watch?v=E3jDPyLcTNk

public class UIBlink : MonoBehaviour
{
    [SerializeField] private float blinkDecaySpeed = 1f; //how fast the effect disappears

    private Image image; //reference the variable it acts on

    private Material materialInstance; //refer to the material
    private float blinkFactor; //refer to the trigger in material/shader editor

    private void Awake() //get the variables
    {
        image = GetComponent<Image>();

        materialInstance = new Material(image.material);
        image.material = materialInstance;
    }

    private void Update() //conditions for change
    {
        if (blinkFactor <= 0f)
        {
            return;
        }

        blinkFactor = Mathf.Lerp(blinkFactor, 0f, Time.deltaTime * blinkDecaySpeed);
        
        if (blinkFactor < 0.01f) //prevent lag
        {
            blinkFactor = 0f;
        }

        ApplyBlinkFactor();
    }

    public void Blink() //set scale to 1 (full white flash)
    {
        blinkFactor = 1f;
        ApplyBlinkFactor();
    }

    private void ApplyBlinkFactor() //apply teh trigger/change
    {
        materialInstance.SetFloat("_BlinkFactor", blinkFactor);

    }
}

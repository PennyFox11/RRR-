using UnityEngine;
using UnityEngine.UI;
//Title: Unity Tutorial: How To Make Characters Blink on Damage - URP Sprite Shader
//Author: PitilT
//Date: 1 January 2026
//Code version: Unity 6000.2.8f1
//Availability: https://www.youtube.com/watch?v=E3jDPyLcTNk

public class UIFlash : MonoBehaviour
{
    [SerializeField] private float flashDecaySpeed = 1f; //can change - how fast flash disappears
    private Image image; //variable it will act on
    private Material materialInstance; //reference mataerial component
    private float blinkControl; //reference trigger in material editor

    private void Awake() // get the variables
    {
        image = GetComponent<Image>();

        materialInstance = new Material(image.material);
        image.material = materialInstance;
    }

    // Update is called once per frame
    private void Update() //check for when to apply effect
    {
        if (blinkControl <= 0f)
        {
            return;
        }

        blinkControl = Mathf.Lerp(blinkControl, 0f, Time.deltaTime * flashDecaySpeed);

        if (blinkControl < 0.01f) //prevents lag
        {
            blinkControl = 0f;
        }

        ApplyBlinkControl();
    }

    public void Blink() //set the blinkControl to 1 (full shift to white)
    {
        blinkControl = 1f;
        ApplyBlinkControl();
    }

    private void ApplyBlinkControl() //apply the trigger/change
    {
        materialInstance.SetFloat("_BlinkControl", blinkControl);
    }
}

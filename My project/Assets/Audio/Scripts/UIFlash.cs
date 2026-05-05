using UnityEngine;
using UnityEngine.UI;
//Title: Unity Tutorial: How To Make Characters Blink on Damage - URP Sprite Shader
//Author: PitilT
//Date: 1 January 2026
//Code version: Unity 6000.2.8f1
//Availability: https://www.youtube.com/watch?v=E3jDPyLcTNk

public class UIFlash : MonoBehaviour
{
    [SerializeField] private float flashDecaySpeed = 1f;
    private Image image;
    private Material materialInstance;
    private float blinkControl;

    private void Awake()
    {
        image = GetComponent<Image>();

        materialInstance = new Material(image.material);
        image.material = materialInstance;
    }

    // Update is called once per frame
    private void Update()
    {
        if (blinkControl <= 0f)
        {
            return;
        }

        blinkControl = Mathf.Lerp(blinkControl, 0f, Time.deltaTime * flashDecaySpeed);

        if (blinkControl < 0.01f)
        {
            blinkControl = 0f;
        }

        ApplyBlinkControl();
    }

    public void Blink()
    {
        blinkControl = 1f;
        ApplyBlinkControl();
    }

    private void ApplyBlinkControl()
    {
        materialInstance.SetFloat("_BlinkControl", blinkControl);
    }
}

using UnityEngine;
using UnityEngine.UI;
//https://www.youtube.com/watch?v=E3jDPyLcTNk 

public class UIBlink : MonoBehaviour
{
    [SerializeField] private float blinkDecaySpeed = 1f;

    private Image image;

    private Material materialInstance;
    private float blinkFactor;

    private void Awake()
    {
        image = GetComponent<Image>();

        materialInstance = new Material(image.material);
        image.material = materialInstance;
    }

    private void Update()
    {
        if (blinkFactor <= 0f)
        {
            return;
        }

        blinkFactor = Mathf.Lerp(blinkFactor, 0f, Time.deltaTime * blinkDecaySpeed);
        
        if (blinkFactor < 0.01f)
        {
            blinkFactor = 0f;
        }

        ApplyBlinkFactor();
    }

    public void Blink()
    {
        blinkFactor = 1f;
        ApplyBlinkFactor();
    }

    private void ApplyBlinkFactor()
    {
        materialInstance.SetFloat("_BlinkFactor", blinkFactor);

    }
}

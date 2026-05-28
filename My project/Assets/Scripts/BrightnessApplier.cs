using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BrightnessApplier : MonoBehaviour
{
    public Volume volume;
    private ColorAdjustments colorAdjustments;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        volume.profile.TryGet(out colorAdjustments);

        ApplyBrightness();
    }

    public void ApplyBrightness()
    {
        if(BrightnessManager.Instance == null)
        {
            return;
        }
        colorAdjustments.postExposure.value = BrightnessManager.Instance.brightness;
    }

}

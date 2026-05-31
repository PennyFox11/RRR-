using UnityEngine;

public class Threshold : MonoBehaviour
{
    private GameObject threshold;
    private bool thresholdDestroyed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        threshold = GameObject.FindGameObjectWithTag("Threshold");
    }

}

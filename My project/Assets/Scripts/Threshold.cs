using UnityEngine;

public class Threshold : MonoBehaviour //this craetes a reference for teh object that vanishes when the key is collected
{
    private GameObject threshold;
    private bool thresholdDestroyed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    {
        threshold = GameObject.FindGameObjectWithTag("Threshold");
    }

}

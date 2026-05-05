//Title: Controlling GameObjects Using Components
//Author: Unity Documentation
//Date: 29 March 2017
//Code vesrion: Version 5.5
//Availability: https://docs.unity3d.com/550/Documentation/Manual/ControllingGameObjectsComponents.html

//Title: Rigidbody2D
//Author: Unity Documentation
//Date: 4 May 2026
//Code version: Unity 6000.4
//Availability: https://docs.unity3d.com/ScriptReference/Rigidbody2D.html
using UnityEngine;

public class RoseSteps : MonoBehaviour
{
    public AudioSource moveSound;
    public Rigidbody2D rb;

    public float movementThreshold = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocity.magnitude > movementThreshold)
        {
            if(!moveSound.isPlaying)
            {
                moveSound.Play();
            }
        }
        else
        {
            if (moveSound.isPlaying)
            {
                moveSound.Stop();
            }
        }
   
    }
}

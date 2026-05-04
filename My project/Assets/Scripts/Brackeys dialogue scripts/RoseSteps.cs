//https://docs.unity3d.com/550/Documentation/Manual/ControllingGameObjectsComponents.html
//https://docs.unity3d.com/ScriptReference/Rigidbody2D.html
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

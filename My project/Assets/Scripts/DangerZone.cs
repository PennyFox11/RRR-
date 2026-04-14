//https://learn.unity.com/course/2D-adventure-robot-repair/unit/health-system/tutorial/add-damage-zones-to-decrease-health-static-hazards?version=6.3//
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.ChangeHealth(-1);

            if(!source.isPlaying)
            {
                source.Play();
            }
        }
    }
}

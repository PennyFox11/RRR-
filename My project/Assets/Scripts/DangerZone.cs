//https://learn.unity.com/course/2D-adventure-robot-repair/unit/health-system/tutorial/add-damage-zones-to-decrease-health-static-hazards?version=6.3//
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    AudioSource source;
    bool playerDead = false;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += HandlePlayerDeath;
    }

    void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= HandlePlayerDeath;
    }

    void HandlePlayerDeath()
    {
        playerDead = true;
        source.Stop();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (playerDead)
        {
            return;
        }

        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.ChangeHealth(-10);

            if(!source.isPlaying)
            {
                source.Play();
            }
        }
    }
}

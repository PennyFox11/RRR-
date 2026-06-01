//this script was adapted from other animation and audio scripts in this project
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public Animator alarmAnimator;
    private SpriteRenderer spriteRenderer;
    public AudioSource source;

    private bool hasPlayed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.CompareTag("Player") && !hasPlayed)
        {
            hasPlayed = true;
            spriteRenderer.enabled = true;
            alarmAnimator.SetTrigger("PlayerCross");
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
    }

    public void HideSprite()
    {
        spriteRenderer.enabled = false;
        hasPlayed = false;
    }


}

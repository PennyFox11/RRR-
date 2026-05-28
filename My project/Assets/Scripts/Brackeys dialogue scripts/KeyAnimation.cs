using UnityEngine;
//This was from tutor help

public class KeyAnimation : MonoBehaviour
{
    public Animator keyAnimator;
    private SpriteRenderer spriteRenderer;

    private bool hasPlayed = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.CompareTag("Player") && !hasPlayed)
        {
            hasPlayed = true;
            spriteRenderer.enabled = true;
            keyAnimator.SetTrigger("PlayerIn");
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            spriteRenderer.enabled = false;
        }
    }

}

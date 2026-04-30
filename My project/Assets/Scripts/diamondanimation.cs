using UnityEngine;

public class diamondanimation : MonoBehaviour
{
    public Animator glimmerAnimator;
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
            glimmerAnimator.SetTrigger("PlayerHer");
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

using UnityEngine;

public class DiamondGlowTrigger : MonoBehaviour
{
    public Animator glowAnimator;
    private SpriteRenderer spriteRenderer;
    private bool hasPlayed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.CompareTag("Player") && !hasPlayed)
        {
            hasPlayed = true;
            spriteRenderer.enabled = true;
            glowAnimator.SetTrigger("collect");
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

using UnityEngine;

public class HealAnimation : MonoBehaviour
{
    public Animator healAnimator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            spriteRenderer.enabled = true;
            healAnimator.SetTrigger("PlayerClose");
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

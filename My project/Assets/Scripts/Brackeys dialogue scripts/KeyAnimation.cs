using UnityEngine;

public class KeyAnimation : MonoBehaviour
{
    public Animator keyAnimator;
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

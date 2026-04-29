using UnityEngine;
using System;

public class key : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.KeyCollected();

            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            Debug.Log("Key Collected");

            gameObject.SetActive(false);
        }
    }

}

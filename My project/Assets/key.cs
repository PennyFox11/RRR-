using UnityEngine;
using System;

public class key : MonoBehaviour
{
    private GameObject threshold;
    private bool thresholdDestroyed;
    [SerializeField] private AudioClip collectSound;

    void Start()
    {
        threshold = GameObject.FindGameObjectWithTag("Threshold");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.KeyCollected();

            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            Debug.Log("Key Collected");

            gameObject.SetActive(false);

            Destroy(threshold);
        }
    }

}

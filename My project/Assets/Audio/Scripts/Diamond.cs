using UnityEngine;
//Title: AudioSource.PlayClipAtPoint
//Author: Unity Documentation
//Date: 4 May 2026
//Code version: Unity 6000.4
//Availability: https://docs.unity3d.com/ScriptReference/AudioSource.PlayClipAtPoint.html

public class Diamond : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null )
        {
            playerInventory.DiamondCollected();

            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            Debug.Log("Diamond Collected");

            gameObject.SetActive(false);

        }
    }
   
}

using UnityEngine;
//https://docs.unity3d.com/ScriptReference/AudioSource.PlayClipAtPoint.html

public class Diamond : MonoBehaviour
{
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null )
        {
            playerInventory.DiamondCollected();

            source.Play();

            gameObject.SetActive(false);

            Debug.Log("Diamond Collected");

        }
    }
   
}

using UnityEngine;

public class Diamond : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null )
        {
            playerInventory.DiamondCollected();

            gameObject.SetActive(false);

            Debug.Log("Diamond Collected");
        }
    }
   
}

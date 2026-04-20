using UnityEngine;
using System;

public class key : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.KeyCollected();

            gameObject.SetActive(false);

            Debug.Log("Key Collected");
        }
    }

}

using System.Collections.ObjectModel;
using UnityEngine;

public class Diamond_collection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
      if(other.CompareTag("Player"))
        {
            
        }
    }

    // Update is called once per frame
    private void Collect()
    {
        Debug.Log("Item Collected");

            Destroy(gameObject);
    }
}

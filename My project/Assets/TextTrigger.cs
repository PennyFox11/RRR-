using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TriggerText : MonoBehaviour
{
    public GameObject textObject;

    private void Start()
    {
        textObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textObject.SetActive(true);
           Destroy(textObject, 3f);

        }
        else
        {
            textObject.SetActive(false);
  
        }
    }
 
}
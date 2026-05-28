using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AreaTrigger1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject UIObject;
    public GameObject trigger;

    void Start()
    {
        UIObject.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            UIObject.SetActive(true);
            print("working");
        }

    }

    void Update()
    {
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        UIObject.SetActive(false);
        Destroy(trigger);
    }
}

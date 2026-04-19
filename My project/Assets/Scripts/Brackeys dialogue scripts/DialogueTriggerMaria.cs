using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerMaria : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject playerdialogueText;
    public GameObject dialoguButton;

    //public GameObject Test;

    public bool isInRange;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            //playerdialogueText.SetActive(true)
            dialoguButton.SetActive(true);
            //Test.SetActive(true);
            Debug.Log("Entered");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            //Test.SetActive(false);
            dialoguButton.SetActive(false);

        }
    }
}

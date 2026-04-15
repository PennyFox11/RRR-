using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerMaria : MonoBehaviour
{
    public Dialogue dialogue;

    private bool isInRange;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            isInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            isInRange = false;
        }
    }

    public void TriggerDialogue()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
            

        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
    }
}

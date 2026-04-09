using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerMaria : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
    }
}

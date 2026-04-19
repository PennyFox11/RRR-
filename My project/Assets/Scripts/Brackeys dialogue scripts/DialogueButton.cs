using UnityEngine;
using UnityEngine.UI;

public class DialogueButton : MonoBehaviour
{
    public Dialogue dialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void TriggerDialogue()
    {
            FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
            Debug.Log("Entered 12");
    }
}

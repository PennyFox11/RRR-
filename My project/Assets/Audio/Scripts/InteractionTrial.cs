using UnityEngine;

public class InteractionTrial : MonoBehaviour
{
    public GameObject interactionIcon;
    //public GameObject Panel;

    public NPC currentNPC;
    

    public void Start()
    {
        if (interactionIcon != null)
        {
            interactionIcon.SetActive(false);
        }
          
    }

    public void Update()
    {
        if (currentNPC != null && Input.GetKeyDown(KeyCode.E))
        {
            //Panel.SetActive(true);
            currentNPC.StartDialogue();
            Debug.Log("Interaction Happened");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //triggers interaction icon to show when in range with an interactable object
    {
        NPC npc = other.GetComponent<NPC>(); //checks if there is an interactable script on the object
        if (npc != null) 
        {
            currentNPC = npc;
            interactionIcon.SetActive(true); //once object is in range, icon will show above player
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        NPC npc = other.GetComponent<NPC>();
        if (npc != null && npc == currentNPC ) //checks if the interactble is the same one that is in range
        {
            if ( interactionIcon != null )
            {
                interactionIcon.SetActive(false); //once object is out of range, the icon will disappear

            }
            
            npc.EndDialogue();

            currentNPC = null;
        }
    }
}

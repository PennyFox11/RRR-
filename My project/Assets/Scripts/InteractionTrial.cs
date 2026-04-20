using UnityEngine;

public class InteractionTrial : MonoBehaviour
{
    public GameObject interactionIcon;
    //public GameObject Panel;

    public NPC npc;
    

    public void Start()
    {
        interactionIcon.SetActive(false);   
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Panel.SetActive(true);
            npc.StartDialogue();
            Debug.Log("Interaction Happened");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //triggers interaction icon to show when in range with an interactable object
    {
        if(other.tag == "Maria") //checks if there is an interactable script on the object
        {
            interactionIcon.SetActive(true); //once object is in range, icon will show above player
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision) //checks if the interactble is the same one that is in range
        {
            interactionIcon.SetActive(false); //once object is out of range, the icon will disappear
            npc.EndDialogue();
        }
    }
}

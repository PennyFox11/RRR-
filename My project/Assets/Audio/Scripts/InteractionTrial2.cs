using UnityEngine;

public class InteractionTrial2 : MonoBehaviour
{


    public GameObject interactionIcon2;
    //public GameObject Panel;

    public NPC2 npc2;


    public void Start()
    {
        interactionIcon2.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Panel.SetActive(true);
            npc2.StartDialogue();
            Debug.Log("Interaction Happened");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //triggers interaction icon to show when in range with an interactable object
    {
        if (other.tag == "Bathtub") //checks if there is an interactable script on the object
        {
            interactionIcon2.SetActive(true); //once object is in range, icon will show above player
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision) //checks if the interactble is the same one that is in range
        {
            interactionIcon2.SetActive(false); //once object is out of range, the icon will disappear
            npc2.EndDialogue();
        }
    }
}

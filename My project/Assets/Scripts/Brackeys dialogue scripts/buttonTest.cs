using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class buttonTest : MonoBehaviour
{
    public GameObject diaButton;
    public Dialogue dialogue;
    
    public GameObject SomethingElse;
    private Animator anim;

    // Update is called once per frame
    void Start()
    {
        Animator anim = gameObject.GetComponent<Animator>();
        SomethingElse.SetActive(false);
    }

    public void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            PlayDialogue();
        }*/
    }

    public void PlayDialogue()
    {
        SomethingElse.SetActive(true);
        anim.Play("DialogueBox_Open");
        StartCoroutine(WaitAbit());
    }

    IEnumerator WaitAbit(int delay = 1)
    {
        yield return new WaitForSeconds(delay);

        FindFirstObjectByType<DialogueManager>().StartDialogue(dialogue);
    }
}

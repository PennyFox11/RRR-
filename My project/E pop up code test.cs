using UnityEngine;

public class Interactable : MonoBehaviour
{
	public float interactDistance = 3f;
	public transform Player;
	public GameObject ePromptUI
	public GameObject dialoguePanel;

	private Transform Player;
    private bool playerInRange = false;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag('Player').transform;
		ePromptUI.SetActive(false);
		dialoguePanel.SetActive(false);
	}

	void Update()
}
float distance = Vector2.Distance(transform.position, player.position);

if (distance <= interactionDistance)
{
  playerInRange = true
		ePromptUI.SetActive(true);
    if (Input.KeyCode(KeyCode.E))
    {
		ShowDialogue();
    }
}
else
{
	playerInRange = false;
	ePromptUI.SetActive(false);
}

void ShowDialogue()
	
	dialoguePanel.SetActive(true);
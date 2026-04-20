//Title: Add an Interaction System to Your Game - Top Down Unity 2D #16
//Author: Game Code Library
//Date: 5 February 2025
//Code Version: Unity 2021.3.23f1 LTS
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{
    private IInteractable interactableInRange = null; //stores the closest interactable object to the player
    public GameObject interactionIcon; //the "E" icon above player when in range with an interactable object

    public GameObject dialoguePanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionIcon.SetActive(false); //to ensure that the "E" is not showing above the player at the beginning of a game
        dialoguePanel.SetActive(false); 
    }

    public void OnInteract(InputAction.CallbackContext context) //checks so that no matter what it is, as long as it is interactable it will perform interactions
    {
        if (context.performed)
        {
            interactableInRange.Interact();
            //dialoguePanel.SetActive(true);

            //dialoguePanel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //triggers interaction icon to show when in range with an interactable object
    {
        if(collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract()) //checks if there is an interactable script on the object
        {
            interactableInRange = interactable;
            interactionIcon.SetActive(true); //once object is in range, icon will show above player
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == interactableInRange) //checks if the interactble is the same one that is in range
        {
            interactableInRange = null; //if it is the same one, deemed null
            interactionIcon.SetActive(false); //once object is out of range, the icon will disappear
        }
    }

}

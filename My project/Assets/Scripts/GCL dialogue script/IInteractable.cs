//Title: Add NPC and Dialogue System to Your Game - Top Down Unity 2D #19
//Author: Game Code Library
//Date: 23 February 2025
//Code Version: Unity 2022.3.20f1 LTS
public interface IInteractable //interactions system for objects player can interact with
{
    void Interact();

    bool CanInteract();
}

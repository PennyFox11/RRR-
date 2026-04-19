//Title: Add a Pause System to your Game! - Top Down Unity 2D #17
//Author: Game Code Library
//Date: 11 February 2025
//Availability: https://www.youtube.com/watch?v=fspxIduosYQ
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool IsGamePaused { get; private set; } = false;

    public static void SetPause(bool pause)
    {
        IsGamePaused = pause;
    }
}

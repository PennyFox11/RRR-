//Title: Timer & on Trigger Events 2D
//Author: Unity Discussions
//Date: May 2020
//Availability: https://discussions.unity.com/t/timer-on-trigger-events-2d/789369

//Title: Can someone help me make a countdown timer for C#,I just need help making a countdown timer
//Author: Unity Discussions
//Date: March 2023
//Availability: https://discussions.unity.com/t/can-someone-help-me-make-a-countdown-timer-for-c-i-just-need-help-making-a-countdown-timer/256846/2 

//Title: OnTrigger events
//Author: Unity Documentation
//Date: 16 April 2026 
//Code version: Unity 6000.3
//Availability: https://docs.unity3d.com/6000.3/Documentation/Manual/collider-interactions-ontrigger.html 

//Title: GAME OVER Menu In Unity Tutorial
//Author: BMo
//Date: 17 March 2022
//Code version: Unity 2020.3.22f1
//Availability: https://www.youtube.com/watch?v=ZfRbuOCAeE8 
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 5f; //countdown is five seconds
    public float originalTime;
    public TextMeshProUGUI timerText;
    private bool isTimerRunning = false;

    void Start()
    {
        originalTime = countdownTime; //timer is at 5 seconds
        timerText.gameObject.SetActive(false); //no text is present
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning && countdownTime > 0) //if the timer is running and not finished
        {
            countdownTime -= Time.deltaTime; //countdown decreases by 1 second
            DisplayTime(countdownTime); //display time remaining
        }
        else if (countdownTime <= 0 && isTimerRunning) //if timer is running and finished
        {
            countdownTime = 0;
            isTimerRunning = false; //timer ends
            OnTimerEnd(); //calls method
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //if collider with "player" tag enters the timer collider
        {
            countdownTime = originalTime; //timer starts at 5
            isTimerRunning = true; //timer starts
            timerText.gameObject.SetActive(true); //text appears
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //if collider with the tag "player" leaves the timer collider
        {
            isTimerRunning = false; //timer stops
            countdownTime = originalTime; //timer resets
            timerText.gameObject.SetActive(false); //text vanishes
        }
    }

    void DisplayTime(float timeToDisplay) //controls time of display
    {
        timerText.text = Mathf.CeilToInt(timeToDisplay).ToString();
    }

    void OnTimerEnd()
    {
        Debug.Log("Time is up!");
        timerText.gameObject.SetActive(false); //text disappears

        PlayerHealth.TriggerGameOver(); //trigger the game over events
    }
}

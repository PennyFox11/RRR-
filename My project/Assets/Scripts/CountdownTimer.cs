//https://discussions.unity.com/t/timer-on-trigger-events-2d/789369
//https://discussions.unity.com/t/can-someone-help-me-make-a-countdown-timer-for-c-i-just-need-help-making-a-countdown-timer/256846/2 
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 5f;
    public TextMeshProUGUI timerText;
    private bool isTimerRunning = false;

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning && countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            DisplayTime(countdownTime);
        }
        else if (countdownTime <= 0)
        {
            countdownTime = 0;
            isTimerRunning = false;
            OnTimerEnd();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTimerRunning)
        {
            isTimerRunning = true;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timerText.text = Mathf.CeilToInt(timeToDisplay).ToString();
    }

    void OnTimerEnd()
    {
        Debug.Log("Time is up!");
    }
}

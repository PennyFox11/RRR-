//https://discussions.unity.com/t/timer-on-trigger-events-2d/789369
//https://discussions.unity.com/t/can-someone-help-me-make-a-countdown-timer-for-c-i-just-need-help-making-a-countdown-timer/256846/2 
//https://docs.unity3d.com/6000.3/Documentation/Manual/collider-interactions-ontrigger.html 
//https://www.youtube.com/watch?v=ZfRbuOCAeE8 
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 5f;
    public float originalTime;
    public TextMeshProUGUI timerText;
    private bool isTimerRunning = false;

    void Start()
    {
        originalTime = countdownTime;
        timerText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning && countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            DisplayTime(countdownTime);
        }
        else if (countdownTime <= 0 && isTimerRunning)
        {
            countdownTime = 0;
            isTimerRunning = false;
            OnTimerEnd();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            countdownTime = originalTime;
            isTimerRunning = true;
            timerText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTimerRunning = false;
            countdownTime = originalTime;
            timerText.gameObject.SetActive(false);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timerText.text = Mathf.CeilToInt(timeToDisplay).ToString();
    }

    void OnTimerEnd()
    {
        Debug.Log("Time is up!");
        timerText.gameObject.SetActive(false);

        PlayerHealth.TriggerGameOver();
    }
}

using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownUI : MonoBehaviour
{
    public static CountdownUI Instance;

    public TMP_Text countdownText; // TextMeshPro reference

    private Coroutine countdownCoroutine;
    private Enemy2Controller currentEnemy;

    private void Awake()
    {
        Instance = this;

        // Ensure text starts hidden
        if (countdownText != null)
            countdownText.text = "";
    }

    public void StartCountdown(float duration, Enemy2Controller enemy)
    {
        currentEnemy = enemy;

        if (countdownCoroutine != null)
            StopCoroutine(countdownCoroutine);

        countdownCoroutine = StartCoroutine(Countdown(duration));
    }

    IEnumerator Countdown(float time)
    {
        float timer = time;

        while (timer > 0)
        {
            // Update countdown display
            countdownText.text = Mathf.Ceil(timer).ToString();

            timer -= Time.deltaTime;
            yield return null;

            // Stop if player leaves detection
            if (!currentEnemy.IsPlayerDetected())
            {
                countdownText.text = "";
                yield break;
            }
        }

        countdownText.text = "0";
        GameOver();
    }

    public void StopCountdown()
    {
        if (countdownCoroutine != null)
            StopCoroutine(countdownCoroutine);

        countdownText.text = "";
    }

    void GameOver()
    {
        Debug.Log("GAME OVER");

        // Pause the game
        Time.timeScale = 0f;

        // Optional: Load a Game Over scene instead
        // SceneManager.LoadScene("GameOverScene");
    }
}
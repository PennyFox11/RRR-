using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownUI : MonoBehaviour
{
    public static CountdownUI Instance;

    public Text countdownText;

    private Coroutine countdownCoroutine;
    private Enemy2Controller currentEnemy;

    private void Awake()
    {
        Instance = this;
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
            countdownText.text = Mathf.Ceil(timer).ToString();
            timer -= Time.deltaTime;

            yield return null;

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

        // Option 1: Pause game
        Time.timeScale = 0f;

        // Option 2: Load scene
        // SceneManager.LoadScene("GameOverScene");
    }
}
using System.Collections;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed = 2f;

    private int currentPointIndex = 0;
    private bool isPlayerDetected = false;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!isPlayerDetected)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        Transform target = patrolPoints[currentPointIndex];

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            currentPointIndex++;

            if (currentPointIndex >= patrolPoints.Length)
                currentPointIndex = 0;
        }
    }

    public void PlayerDetected()
    {
        if (isPlayerDetected) return;

        isPlayerDetected = true;
        audioSource.Play();

        CountdownUI.Instance.StartCountdown(10f, this);
    }

    public void PlayerLost()
    {
        isPlayerDetected = false;
        audioSource.Stop();

        CountdownUI.Instance.StopCountdown();
    }

    public bool IsPlayerDetected()
    {
        return isPlayerDetected;
    }
}
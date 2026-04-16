//https://www.youtube.com/watch?v=ZfRbuOCAeE8
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed;
    public Rigidbody2D Rigidbody;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += DisablePlayerMovement;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= DisablePlayerMovement;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnablePlayerMovement();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction.Normalize();

        Rigidbody.linearVelocity = direction * MoveSpeed;

    }
    private void DisablePlayerMovement()
    {
        Rigidbody.bodyType = RigidbodyType2D.Static;
    }

    private void EnablePlayerMovement()
    {
        Rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }
}

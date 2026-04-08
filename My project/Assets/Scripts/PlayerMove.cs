using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed = 5f;       // assign in Inspector
    private Rigidbody2D rb;            // renamed variable

    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get player input
        moveInput.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        moveInput.y = Input.GetAxisRaw("Vertical");   // W/S or Up/Down
        moveInput.Normalize();
    }

    void FixedUpdate()
    {
        // Apply movement to Rigidbody
        rb.linearVelocity = moveInput * MoveSpeed;
    }
}
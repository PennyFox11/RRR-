using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed;
    public Rigidbody2D Rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction.Normalize();

        Rigidbody.linearVelocity = direction * MoveSpeed;

    }
}

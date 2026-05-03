using UnityEngine;


public class PlayerRunning : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;
    bool isRunning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        isRunning = false;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.y += 1;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection.y -= 1;
        }
        if (Input.GetKey(KeyCode.A)  || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x -= 1;
            isRunning = true;
            transform.localScale = new Vector3(-1, transform.localScale.y);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x += 1;
            isRunning = true;
            transform.localScale = new Vector3(1, transform.localScale.y);
        }

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
        animator.SetBool("Run", isRunning);
    }
}

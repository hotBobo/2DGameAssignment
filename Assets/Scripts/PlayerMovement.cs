using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8.0f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();
        if (moveInput.sqrMagnitude > 0)
        {
            anim.SetFloat("MoveX", moveInput.x);
            anim.SetFloat("MoveY", moveInput.y);
            anim.SetBool("isMoving", true);
        } else anim.SetBool("isMoving", false);
        // Go to main menu if escape is pressed
        if (InputSystem.actions["Escape"].triggered)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
    }

    // Fixed Update
    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
}

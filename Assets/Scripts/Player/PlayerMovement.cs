using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Vector2 moveInput;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        rb.linearVelocity =
            moveInput * moveSpeed;
    }


    public void OnMove(InputValue value)
    {
        moveInput =
            value.Get<Vector2>().normalized;
    }


    private void OnDisable()
    {
        if (rb != null)
        {
            rb.linearVelocity =
                Vector2.zero;
        }
    }
}
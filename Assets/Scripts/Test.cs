using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    private Rigidbody2D rb;
    private InputAction movementAction;
    private Vector2 movementInput;

    public float moveSpeed = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movementAction = GetComponent<PlayerInput>().actions["Movement"];
    }

    private void OnEnable()
    {
        movementAction.Enable();
        movementAction.performed += OnMovementPerformed;
        movementAction.canceled += OnMovementCanceled;
    }

    private void OnDisable()
    {
        movementAction.Disable();
        movementAction.performed -= OnMovementPerformed;
        movementAction.canceled -= OnMovementCanceled;
    }

    private void FixedUpdate()
    {
        rb.velocity = movementInput * moveSpeed;
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext context)
    {
        movementInput = Vector2.zero;
    }
}
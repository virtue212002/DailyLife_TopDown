using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float diagonalFactor = 0.1f;
    public Rigidbody2D rb;
    public Animator animator;

    [SerializeField]
    private InputActionReference movement, attack, pointerPosition;

    //private input pointerInput, movementInput;

    private WeaponParent weaponParent;
    Vector2 velocity, pointerInput;
    Vector3 mousePos;
    //Vector2 direction;

    private void Awake()
    {
        weaponParent = GetComponentInChildren<WeaponParent>();
    }


    // Update is called once per frame
    void Update()
    {  

        velocity = Vector2.zero;
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");
        UpdateAnimation();

        pointerInput = getPointerInput();
        // weaponParent.pointerPosition = pointerInput;
        // Debug.Log(pointerInput.ToString());
        //direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
    }

    private void FixedUpdate()
    {  
        // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
// Sử dụng hệ số nhân để giảm tốc độ di chuyển chéo
        if (velocity.x != 0 && velocity.y != 0)
        {
        rb.MovePosition(rb.position + velocity.normalized * moveSpeed * diagonalFactor * Time.fixedDeltaTime);
            // moveVector = moveVector.normalized * moveSpeed * diagonalFactor;
        }

        // Di chuyển player
        // transform.Translate(moveVector * Time.deltaTime);
        rb.MovePosition(rb.position + velocity * moveSpeed * Time.fixedDeltaTime);
    }

    void UpdateAnimation()
    {
        if (velocity != Vector2.zero)
        {
            // UpdateMovement();
            FixedUpdate();
            animator.SetBool("Walking", true);
            animator.SetFloat("Horizontal", velocity.x);
            animator.SetFloat("Vertical", velocity.y);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    void UpdateMovement()
    {
        // Sử dụng hệ số nhân để giảm tốc độ di chuyển chéo
        if (velocity.x != 0 && velocity.y != 0)
        {
        rb.MovePosition(rb.position + velocity.normalized * moveSpeed * diagonalFactor * Time.fixedDeltaTime);
            // moveVector = moveVector.normalized * moveSpeed * diagonalFactor;
        }

        // Di chuyển player
        // transform.Translate(moveVector * Time.deltaTime);
        rb.MovePosition(rb.position + velocity * moveSpeed * Time.fixedDeltaTime);
    }

    private Vector2 getPointerInput()
    {
        mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.applyRootMotion = false;
    }

    void Update()
    {
        // Gerakkan karakter menggunakan Rigidbody2D
        Debug.Log("Move Input: " + moveInput);
        
        rb.velocity = moveInput * moveSpeed;

        // Update parameter animator
        bool isWalking = moveInput != Vector2.zero;
        animator.SetBool("isWalking", isWalking);

        if (isWalking)
        {
            animator.SetFloat("InputX", moveInput.x);
            animator.SetFloat("InputY", moveInput.y);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        // Baca input gerakan dari sistem input baru
        moveInput = context.ReadValue<Vector2>();
    }
}
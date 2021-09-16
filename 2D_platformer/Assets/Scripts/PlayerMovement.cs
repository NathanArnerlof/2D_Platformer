using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a class
public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator; 

    public GameObject groundCheck;
    private bool isGrounded;

    public float movementSpeed = 3f;
    private float moveDirection = 0f;
    private bool isJumpPressed = false;
    public float jumpForce = 2f;

    private bool isFacingLeft = true;

    private Vector3 velocity;
    public float smoothTime = 0.2f;

    public void Start() {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    } 

    void Update() {
        moveDirection = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) == true) {
            isJumpPressed = true;
            animator.SetTrigger("DoJump");
        }

        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(moveDirection)); 

    } 

    private void FixedUpdate() {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);

        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject != gameObject) {
                isGrounded = true;
            }
        }

        Vector3 calculatedMovement = Vector3.zero;
        float verticalVelocity = 0f;

        if (isGrounded == false) {
            verticalVelocity = rigidBody2D.velocity.y;
        }

        calculatedMovement.x = movementSpeed * 100f * moveDirection * Time.fixedDeltaTime;
        calculatedMovement.y = verticalVelocity;
        Move(calculatedMovement, isJumpPressed);
        isJumpPressed = false; 
    }


    private void Move(Vector3 moveDirection, bool isJumpPressed) {
        rigidBody2D.velocity = Vector3.SmoothDamp(rigidBody2D.velocity, moveDirection, ref velocity, smoothTime);

        if (isJumpPressed == true && isGrounded == true) { 
            rigidBody2D.AddForce(new Vector2(0f, jumpForce * 100f));
        }

        if (moveDirection.x > 0f && isFacingLeft == false) {
            FlipSpriteDirection();
        } else if (moveDirection.x < 0f && isFacingLeft == true) {
            FlipSpriteDirection(); 
        }
    }

        private void FlipSpriteDirection() {
            spriteRenderer.flipX = !isFacingLeft;
            isFacingLeft = !isFacingLeft;
   
        }

    public bool isFalling() { 
        if (rigidBody2D.velocity.y < -1f) {
            return true;
        }
        return false;
    }


} 
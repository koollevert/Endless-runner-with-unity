using UnityEngine;

public class JumpSquat : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveDirection;
    private bool isJumping = false;
    private float jumpSpeed = 10.0f;
    private float gravity = 20.0f;
    private float jumpTime = 0.0f;
    private float jumpDuration = 0.2f;
    private float squatDuration = 0.2f;
    private float squatStartTime = 0.0f;
    private float squatEndTime = 0.0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the player is on the ground
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Set the flag to start the jump squat
                isJumping = true;
                squatStartTime = Time.time;
                squatEndTime = squatStartTime + squatDuration;
            }
        }

        // Handle the jump squat movement
        if (isJumping)
        {
            // Squat down for a short period before jumping
            if (Time.time < squatEndTime)
            {
                moveDirection.y = -1.0f;
            }
            // Jump up
            else if (jumpTime < jumpDuration)
            {
                moveDirection.y = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            // End the jump squat
            else
            {
                isJumping = false;
                jumpTime = 0.0f;
            }
        }

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the character
        controller.Move(moveDirection * Time.deltaTime);
    }
}

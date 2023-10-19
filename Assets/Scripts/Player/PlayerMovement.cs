using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundDistance = 0.4f;
    [SerializeField]
    private LayerMask groundMask;
    private bool isGrounded;

    private float speed;
    [SerializeField]
    private float walkSpeed = 12f;
    [SerializeField]
    private float runSpeed = 20f;
    [SerializeField]
    private float runAcceleration = 0.1f;
    [SerializeField] 
    private float runDeceleration = 0.2f;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private float jumpHeight = 3f;

    Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        speed = walkSpeed;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Reset falling velocity once grounded.
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        // The player moves faster while holding the run button.
        if (Input.GetButton("Run") && isGrounded)
        {
            speed += runAcceleration * Time.deltaTime;
        } else
        {
            speed -= runDeceleration * Time.deltaTime;
        }
        speed = Mathf.Clamp(speed, walkSpeed, runSpeed);
        controller.Move(speed * Time.deltaTime * move);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}

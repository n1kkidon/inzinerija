using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Toggle CheatToggle;
    public static bool respawn = false;
    public static bool walking = false;

    public float speed = 6;
    public float gravity = -50f;
    public float jumpHeight = 3;
    public float respawn_Height = -10f;
    public float groundDistance = 0.4f;
    public static Vector3 respawn_point = new Vector3(1, 1.5f, 0);
    Vector3 velocity;
    bool isGrounded;
    public AudioSource playJumpSound;
    public AudioSource walkSound;
    public AudioSource fallSound;

    public Transform groundCheck;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    public static bool canBounce = false;
    public bool canBounce2;

    public Transform groundCheckBounce;
    public LayerMask groundMaskBounce;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        canBounce2 = true;
    }

    void Update()
    {
        if (CheatToggle.isOn)
        {
            walkSound.Pause();
            movementCheat();     
        }
        else 
        {
            movement();
        }    
    }

    void movement()
    {
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            playJumpSound.Play();
        }
        if (velocity.y < -26)
        {
            fallSound.Play();
        }
        // Respawn
        if (this.transform.position.y < respawn_Height)
        {
            controller.enabled = false;
            transform.position = respawn_point;
            respawn = true;
            controller.enabled = true;
        }
        else
            respawn = false;
        // Bounce
        canBounce = Physics.CheckSphere(groundCheckBounce.position, groundDistance, groundMaskBounce);
        if (canBounce)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2 * -2 * gravity);
        }
        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            walking = true;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            walking = false;
        }
        if (!isGrounded)
            walking = false;
        
        if (isGrounded && direction.magnitude <= 0)
        { 
            if ((!walkSound.isPlaying) && (walkSound.time != 0))
            { 
                walkSound.UnPause(); 
            } else
            {
                walkSound.Play();
            }
        }
        
        if (!isGrounded) 
        { 
            if (walkSound.isPlaying) 
            { 
                walkSound.Pause();
            }
        }
    }


    void movementCheat()
    {
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            //playJumpSound.Play(); Gets a bit loud innit
        }
        // Respawn
        if (this.transform.position.y < respawn_Height)
        {
            controller.enabled = false;
            transform.position = respawn_point;
            respawn = true;
            controller.enabled = true;
        }
        else
            respawn = false;
        // Bounce
        canBounce = Physics.CheckSphere(groundCheckBounce.position, groundDistance, groundMaskBounce);
        if (canBounce)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2 * -2 * gravity);
        }
        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
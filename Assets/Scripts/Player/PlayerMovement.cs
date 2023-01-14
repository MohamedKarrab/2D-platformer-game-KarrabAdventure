using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    // new input system
    public PlayerControls playerControls;
    private InputAction move;
    private InputAction fire;
    private InputAction jump;
    private InputAction crouch;
    // *****************************  

    public Transform firePoint;
    public GameObject bulletPrefab;

    public Animator animator;
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jumpKeyWasPressed = false;
    bool crouchKeyWasPressed = false;

    public GameObject pauseMenu;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    
    public void TakeInput(PlayerControls playerControls)
    {     
            Debug.Log("Movement Enabled");
            move = playerControls.Player.Move;
            move.Enable();
            move.performed += Move;
            move.canceled += Move;
            jump = playerControls.Player.Jump;
            jump.Enable();
            jump.performed += Jump;
            fire = playerControls.Player.Fire;
            fire.Enable();
            fire.performed += Fire;
            crouch = playerControls.Player.Crouch;
            crouch.Enable();
            crouch.performed += Crouch;
            crouch.canceled += Crouch;
       
    }

    public void StopInput()
    {
        move.Disable();
        jump.Disable();
        fire.Disable();
        crouch.Disable();
        Debug.Log("Movement Disabled"); 
  
    }

    void Update()
    {     
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));   
    }

 
    private void FixedUpdate()
    {      
        controller.Move(horizontalMove * Time.deltaTime , crouchKeyWasPressed, jumpKeyWasPressed);
        jumpKeyWasPressed = false;
    }

    public void Move(InputAction.CallbackContext context)
    {      
        if (context.performed)
        {
            Vector2 inputVector = context.ReadValue <Vector2>();
            horizontalMove = inputVector.x * runSpeed;
        }
        if (context.canceled)
        {
            horizontalMove = 0;
        }
    }
    public void Fire(InputAction.CallbackContext context)
    {
        if (firePoint)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        jumpKeyWasPressed = true;
        if (animator)
        {
            animator.SetBool("IsJumping", true);
        }
    }

    public void Crouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            crouchKeyWasPressed = true;
        }
        else if (context.canceled)
        {
            crouchKeyWasPressed = false;
        }
    }




    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }



    //*********************** Android Controls ****************************
    
    public void AndroidFire()
    {
        if (firePoint)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
    public void AndroidJump()
    {
        jumpKeyWasPressed = true;
        if (animator)
        {
            animator.SetBool("IsJumping", true);
        }
    }
    
    public void AndroidMoveRight()
    {
        horizontalMove = 1 * runSpeed;
    }
    public void AndroidMoveLeft()
    {
        horizontalMove = -1 * runSpeed;
    }
    
    public void AndroidButtonUp()
    {
        horizontalMove = 0;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
            Time.timeScale = 0f;
    }

}

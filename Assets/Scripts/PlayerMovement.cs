using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls playerControls;

    private Transform playerTransform;
    public Transform groundCheck;

    public Rigidbody2D rb2d;

    public BoxCollider2D platformCollider;

    public LayerMask ground;
    public LayerMask platform;

    private Vector2 playerX;
    private Vector2 jumpForce;

    public float moveSpeed;
    public float checkRadius;
    public float checkRadiusPlatform;

    public int jumpHeight;

    public bool isGrounded;
    public bool onPlatform;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerTransform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
        playerControls.Player.Jump.performed -= Jump;
        playerControls.Player.PlatformDown.performed -= PlatformDown;
    }

    private void Start()
    {
        playerControls.Player.Jump.performed += Jump;
        playerControls.Player.PlatformDown.performed += PlatformDown;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
        onPlatform = Physics2D.OverlapCircle(groundCheck.position, checkRadiusPlatform, platform);

        Vector2 movement = playerControls.Player.Move.ReadValue<Vector2>();
        playerX = playerTransform.position;
        playerX.x += movement.x * moveSpeed * Time.fixedDeltaTime;
        playerTransform.position = playerX;      
    }
    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            Debug.Log("jumped");
            jumpForce.y = jumpHeight;
            rb2d.AddForce(jumpForce);
        }
    }  
    private void PlatformDown(InputAction.CallbackContext context)
    {
        Debug.Log("platform down");
        platformCollider = Physics2D.OverlapCircle(groundCheck.position, checkRadiusPlatform, platform).GetComponent<BoxCollider2D>();
        if (onPlatform)
        {
            platformCollider.enabled = false;
            Invoke("EnablePlatform", 1f);
        }
    }
    private void EnablePlatform()
    {
        platformCollider.enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls playerControls;

    private Transform playerTransform;

    public Rigidbody2D rb2d;

    private Vector2 playerX;
    private Vector2 playerY;
    private Vector2 playerPos;

    public float moveSpeed; 

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
    }
    private void FixedUpdate()
    {
        Vector2 movement = playerControls.Player.Move.ReadValue<Vector2>();
        playerX = playerTransform.position;
        playerY = playerTransform.position;
        playerX.x += movement.x * moveSpeed * Time.fixedDeltaTime;
        playerY.y += movement.y * moveSpeed * Time.fixedDeltaTime;
        playerPos.x = playerX.x;
        playerPos.y = playerY.y;
        rb2d.MovePosition(playerPos);
    }      
}

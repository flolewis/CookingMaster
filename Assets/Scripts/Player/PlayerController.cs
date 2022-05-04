using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [Header("Player Variables")]
    public Rigidbody rb;
    public float moveSpeed = 5f;
    private Vector2 moveDirection = Vector2.zero;

    [Header("Input")]
    [SerializeField]
    private PlayerControls playerControls;
    private InputAction move,fire;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }
    private void OnDisable()
    {
        move.Disable();
    }
    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x*moveSpeed, 0.05f, moveDirection.y*moveSpeed);
    }
}

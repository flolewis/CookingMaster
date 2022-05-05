using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public enum Player { 
    Player1,
    Player2
}
public class PlayerController : MonoBehaviour
{
    [Header("Player Variables")]
    [SerializeField]
    private Player player;
    private Rigidbody rb;
    [SerializeField]
    private float playerRange;
    public Transform[] interactiveAreaList;
    [SerializeField]
    private float moveSpeed = 5f;
    private Vector2 moveDirection = Vector2.zero;
    [SerializeField]
    private Transform closestIntArea;

    [Header("Input")]
    [SerializeField]
    private PlayerControls playerControls;
    private InputAction move,fire;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {

        if (player == Player.Player1)
        {
            move = playerControls.Player1.Move;
        }
        else
        {
            move = playerControls.Player2.Move;
        }
        move.Enable();
    }
    private void OnDisable()
    {
        move.Disable();
    }
    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        closestIntArea = GetClosestInteractiveArea();
        if (closestIntArea != null) {
            closestIntArea.GetComponent<InteractiveArea>().isInteractable = true;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x*moveSpeed, 0.05f, moveDirection.y*moveSpeed);
    }
    private Transform GetClosestInteractiveArea() {
        float closestDist = Mathf.Infinity;
        Transform closestArea = null;

        foreach (Transform area in interactiveAreaList) {
            float currentDist;
            currentDist = Vector3.Distance(transform.position, area.position);
            if (currentDist < closestDist)
            {
                closestDist = currentDist;
                if(closestIntArea!=null)
                closestIntArea.GetComponent<InteractiveArea>().isInteractable = false;
                closestArea = area; 
            }
        }
        if (closestDist > playerRange)
        {
            if (closestIntArea != null)
                closestIntArea.GetComponent<InteractiveArea>().isInteractable = false;
            closestArea = null;
        }
        return closestArea;
    }
}

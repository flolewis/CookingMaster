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
    private Transform closestIntArea, grabPoint;
    private InteractiveArea intArea;
    public Items tempHeld;
    [Header("Input")]
    [SerializeField]
    private PlayerControls playerControls;
    private InputAction move,fire,grab;

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
            fire = playerControls.Player1.Fire;
            grab = playerControls.Player1.Grab;
        }
        else
        {
            move = playerControls.Player2.Move;
            fire = playerControls.Player2.Fire;
            grab = playerControls.Player2.Grab;
        }
        move.Enable(); 
        fire.Enable();
        grab.Enable();
    }
    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
        grab.Enable();
    }
    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        closestIntArea = GetClosestInteractiveArea();
        ActionEvents();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x*moveSpeed, 0.05f, moveDirection.y*moveSpeed);
        if (move.triggered)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
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
    public void HoldItem(ItemsEnum item) {
        GetComponent<ItemController>().AddItem(item);
    }
    private void ActionEvents() {
        if (closestIntArea != null)
        {
            intArea = closestIntArea.GetComponent<InteractiveArea>();
            intArea.isInteractable = true;
            if (fire.triggered) {
                switch (intArea.area) {
                    case InteractiveAreaEnum.Ingredients:

                        intArea.onInteract.AddListener(() => HoldItem(closestIntArea.GetComponent<InteractiveArea>().item));
                        intArea.onInteract.Invoke();
                        intArea.onInteract.RemoveAllListeners();

                        break;
                    case InteractiveAreaEnum.ChoppingBoard:
                        var chopController = intArea.GetComponent<ChoppingBoardController>();
                        var itemController = GetComponent<ItemController>();
                        if (itemController.heldItems.Count > 0)
                        {
                            tempHeld = new Items();
                            //chopController.ResetHeld();
                            intArea.onInteract.AddListener(() => {
                                if (chopController.heldItem.item == ItemsEnum.None)
                                {
                                    chopController.chopStart.AddListener(()=> {
                                        move.Disable();
                                        tempHeld.SetItems(itemController.heldItems[0].item, Status.chopped);
                                        chopController.heldItem = tempHeld;
                                        itemController.heldItems.RemoveAt(0);
                                    });
                                    //chopController.chopping.AddListener(() => );
                                    chopController.chopEnd.AddListener(() =>
                                    {
                                        move.Enable();
                                        itemController.heldItems.Add(tempHeld);
                                    });
                                    StartCoroutine(chopController.Chop());
                                }
                            });
                        }
                        intArea.onInteract.Invoke();
                        intArea.onInteract.RemoveAllListeners();

                        break;

                    case InteractiveAreaEnum.Plate:
                        var plateController = intArea.GetComponent<PlateController>();
                        if (plateController.isInteractable)
                        {
                            itemController = GetComponent<ItemController>();
                            plateController.AddItem(itemController.heldItems[0].item, itemController.heldItems[0].status);
                            itemController.heldItems.RemoveAt(0);
                        }
                        break;
                }
            }
            if (grab.triggered) {
                if (intArea.area == InteractiveAreaEnum.Plate) {
                    intArea.gameObject.transform.parent = this.transform;
                    intArea.transform.position = grabPoint.position;
                    intArea.GetComponent<PlateController>().isInteractable = false;
                }
            }
        }
    }
}

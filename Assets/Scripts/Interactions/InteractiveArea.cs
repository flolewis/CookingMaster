using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class InteractiveArea : MonoBehaviour
{
    public GameObject interactUI;
    public bool isInteractable;
    public UnityEvent onInteract;

    private void Update()
    {
        interactUI.SetActive(isInteractable);
    }
}

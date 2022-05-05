using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class InteractiveArea : MonoBehaviour
{
    public GameObject interactUI;
    public bool isInteractable,isItem;
    public UnityEvent onInteract;
    public ItemsEnum item;

    private void Update()
    {
        interactUI.SetActive(isInteractable);
    }
}

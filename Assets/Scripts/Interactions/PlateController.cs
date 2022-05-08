using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    public int maxItems = 3;
    public List<Items> heldItems = new List<Items>();
    public bool isInteractable = true;
    private void Start()
    {
        isInteractable = true;
        heldItems.Clear();
    }
    public void AddItem(ItemsEnum item,Status status)
    {
        if (heldItems.Count < maxItems)
        {
            Items i = new Items();
            i.SetItems(item, status);
            heldItems.Add(i);
        }
    }
}

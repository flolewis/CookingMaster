using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int maxItems = 2;
    public List<Items> heldItems = new List<Items>();
    private void Start()
    {
        heldItems.Clear();
        AddItem(ItemsEnum.None);
        AddItem(ItemsEnum.None);
    }
    public void AddItem(ItemsEnum item) {
        if (heldItems.Count < maxItems)
        {
            Items i = new Items();
            i.SetItems(item, Status.whole);
            heldItems.Add(i);
        }
    }
}

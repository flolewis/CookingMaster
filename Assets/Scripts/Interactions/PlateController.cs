using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    public int maxItems = 3;
    public List<Items> heldItems = new List<Items>();
    public bool isInteractable = true;
    public PlayerData pdata;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlatePoint")) {
            pdata = null;
            this.gameObject.transform.parent = other.transform.parent;
            this.gameObject.transform.position = other.transform.position;
            this.gameObject.transform.rotation = other.transform.rotation;
            isInteractable = true;
        }else if (other.CompareTag("CustomerPoint"))
        {
            var oc = other.GetComponent<OrderController>();
            if (oc.order.Count != heldItems.Count)
            {
                Debug.Log("L");
                heldItems.Clear();
            }
            else
            {
                foreach (Items item in heldItems.ToList())
                {

                    if (oc.order.Any(i => i.item == item.item && i.status == item.status))
                    {
                        heldItems.Remove(item);
                    }
                }
                if (heldItems.Count <= 0)
                {
                    Debug.Log("W");
                    pdata.AddScore(oc.order.Count);
                    heldItems.Clear();
                }
                else
                {
                    Debug.Log("L");
                    heldItems.Clear();
                }
            }
            oc.RandomizeOrder();
        }
    }
}

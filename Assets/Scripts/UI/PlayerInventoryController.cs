using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class PlayerInventoryController : MonoBehaviour
{
    public ItemController itemController;

    public List<Items> heldItems = new List<Items>();

    public Image[] images;

    public Color[] color;

    void Update()
    {
        heldItems = itemController.heldItems;
        for(int i = 0;i<heldItems.Count;i++) {
            if (heldItems[i].item == ItemsEnum.Chicken)
            {
                images[i].color = color[0];
            }
            else if (heldItems[i].item == ItemsEnum.Lettuce)
            {
                images[i].color = color[1];
            }
            else if (heldItems[i].item == ItemsEnum.Tomato)
            {
                images[i].color = color[2];
            }
            else if (heldItems[i].item == ItemsEnum.None)
            {
                images[i].color = color[3];
            }
            else
            {
                images[i].color = color[3];
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public enum InteractiveAreaEnum 
{ 
    Ingredients,
    Trash,
    ChoppingBoard,
    Plate,
    Customer
}
[System.Serializable]
public enum ItemsEnum
{
    Tomato = 0,
    Lettuce = 1,
    Chicken = 2,
    None
}
[System.Serializable]
public enum Status
{
    whole = 0,
    chopped = 1
}
[System.Serializable]
public class Items 
{
    public ItemsEnum item;
    public Status status;

    public void SetItems(ItemsEnum i,Status s) {
        item = i;
        status = s;
    }
}

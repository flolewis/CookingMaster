
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public enum ItemsEnum
{
    Tomato,
    Lettuce,
    Chicken
}
[System.Serializable]
public enum Status
{
    whole,
    chopped
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

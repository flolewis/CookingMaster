using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ChoppingBoardController : MonoBehaviour
{
    public float chopTime;
    public Items heldItem;
    public UnityEvent chopStart = new UnityEvent(), chopping = new UnityEvent(), chopEnd = new UnityEvent();
    public bool isChopping;
    private void Start()
    {
        ResetHeld();
    }
    private void Update()
    {
        if (isChopping) {
            chopping.Invoke();
        }
    }
    public void AddItem(ItemsEnum item)
    {
            Items i = new Items();
            i.SetItems(item, Status.whole);
            heldItem = i;
    }
    public IEnumerator Chop()
    {
        chopStart.Invoke();
        isChopping = true;
        yield return new WaitForSecondsRealtime(chopTime);
        isChopping = false;
        chopEnd.Invoke();
        chopStart.RemoveAllListeners();
        chopEnd.RemoveAllListeners();
        yield return new WaitForEndOfFrame();

        AddItem(ItemsEnum.None);
    }
    public void ResetHeld()
    {
        heldItem.SetItems(ItemsEnum.None, Status.whole);
    }
}

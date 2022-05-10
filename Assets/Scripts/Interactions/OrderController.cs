using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OrderController : MonoBehaviour
{
    public OrderUIController orderUIController;
    public Timer timer;
    public List<Items> order = new List<Items>();
    public UnityEvent onOrderComplete;

    private void OnEnable()
    {
        RandomizeOrder();
    }
    public void RandomizeOrder()
    {
        timer.timer = 0;
        order.Clear();
        int itemCount = Random.Range(1, 4);
        for (int x = 0; x < itemCount; x++)
        {

            var i = new Items();
            int item = Random.Range(0, 3);
            int status = Random.Range(0, 2);

            i.SetItems((ItemsEnum)item, (Status)status);
            order.Add(i);
        }
        orderUIController.ShowOrder();
        timer.timer = itemCount * 15;
        timer.StartTimer();
    }
}

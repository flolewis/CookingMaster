using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderUIController : MonoBehaviour
{
    public Items[] order = new Items[0];

    private void OnEnable()
    {
        RandomizeOrder();
    }
    public void RandomizeOrder() {
        int itemCount = Random.Range(1, 4);
        order = new Items[itemCount];
        for(int x = 0;x<itemCount;x++) {

            var i = new Items();
            int item = Random.Range(0, 3);
            int status = Random.Range(0, 2);

            i.SetItems((ItemsEnum)item, (Status)status);
            order[x] = i;
        }
    }
}

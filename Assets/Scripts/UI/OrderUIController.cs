using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OrderUIController : MonoBehaviour
{
    public OrderController orderController;
    public TextMeshProUGUI ui;
    public void ShowOrder() {
        var tempString = "";
        foreach (Items item in orderController.order) {
            tempString += item.item.ToString() + "(" + item.status.ToString() + ")\n";
        }
        ui.text = tempString;
    }
}

using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBuyItem : MonoBehaviour
{
    private Item item;
    
    public void Setup(Item _item)
    {
        item = _item;
    }
    
    public void Buy()
    {
        Inventory.Controller.instance.AddItem(item);
        Inventory.Controller.instance.RefreshUI();
    }
}

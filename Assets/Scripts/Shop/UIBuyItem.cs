using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIBuyItem : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private Item item;
    
    public void Setup(Item _item)
    {
        item = _item;
    }
    
    public void Buy()
    {
        if (MoneyManager.instance.canAfford(item.goldValue) == true)
        {
            Inventory.Controller.instance.AddItem(item);
            MoneyManager.instance.RemoveMoney(item.goldValue);
            Inventory.Controller.instance.RefreshUI();
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color32(0,85,64,100);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color32(0,0,0,100);
    }
}

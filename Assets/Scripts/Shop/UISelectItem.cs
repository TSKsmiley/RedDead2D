using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UISelectItem : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    // Internal UI references
    private Image selectItemSprite;

    private TextMeshProUGUI selectItemName;
    private TextMeshProUGUI selectItemDescription;
    private Button btnBuy;
    private GameObject outline;

    // Internal item references
    private Sprite itemSprite;
    private string itemName;
    private string itemDescription;
    private int itemGoldValue;
    private Item item;
    
    public void Setup(Item _item, Image _itmSprite, TextMeshProUGUI _itmName, TextMeshProUGUI _itmDescription, Button _btnBuy, GameObject _outline)
    {
        item = _item;
        // ITEM SETUP
        itemSprite = item.sprite;
        itemName = item.name;
        itemDescription = item.description;
        itemGoldValue = item.goldValue;
        
        // UI Setup
        selectItemSprite = _itmSprite;
        selectItemName = _itmName;
        selectItemDescription = _itmDescription;
        btnBuy = _btnBuy;
        outline = _outline;
    }
    
    public void RefreshSelected()
    {
        selectItemSprite.sprite = itemSprite;
        selectItemName.text = itemName;
        selectItemDescription.text = itemDescription;
        btnBuy.GetComponent<UIBuyItem>().Setup(item);
        btnBuy.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = $"Buy for ${itemGoldValue.ToString()}";
    }
    
    
    
    public void OnSelect(BaseEventData eventData)
    {
        outline.SetActive(true);
        //gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 1.1f, gameObject.transform.localScale.y * 1.1f);
        RefreshSelected();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        outline.SetActive(false);
        //gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x / 1.1f, gameObject.transform.localScale.y / 1.1f);
    }
}

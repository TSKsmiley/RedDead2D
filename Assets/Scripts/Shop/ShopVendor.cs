using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopVendor : MonoBehaviour
{
    public List<Item> availableItems;
    
    [Header("UI")] 
    public GameObject itemBox;

    public GameObject shopUI;
    
    public RectTransform itemBoxParent;
    
    [Header("Selected Item UI")] 
    public Image selectItemSprite;

    public TextMeshProUGUI selectItemName;
    public TextMeshProUGUI selectItemDescription;
    public Button btnBuy;

    private bool isOpen = false;
    private List<GameObject> spawnedButtons = new List<GameObject>();

    public void OpenShop(Rigidbody2D _rb)
    {
        isOpen = !isOpen;
        if (isOpen == false)
        {
            CloseShop(_rb);
            return;
        }

        spawnedButtons = new List<GameObject>();
        
        _rb.constraints = RigidbodyConstraints2D.FreezeAll;
        
        foreach (Item item in availableItems)
        {
            GameObject g = Instantiate(itemBox, itemBoxParent);
            g.SetActive(true);
            spawnedButtons.Add(g);
            
            g.GetComponent<UISelectItem>().Setup(item, selectItemSprite, selectItemName, selectItemDescription, btnBuy);
            
            g.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = item.name;
            g.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().sprite = item.sprite;
        }

        EventSystem.current.SetSelectedGameObject(spawnedButtons[0]);
        
        shopUI.SetActive(true);
        spawnedButtons[0].GetComponent<UISelectItem>().RefreshSelected();
    }

    private void CloseShop(Rigidbody2D _rb)
    {
        _rb.constraints = RigidbodyConstraints2D.None;
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        shopUI.SetActive(false);
        spawnedButtons.ForEach(x => Destroy(x)); // We destroy our buttons
    }
}

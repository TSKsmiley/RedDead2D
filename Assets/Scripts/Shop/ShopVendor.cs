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

    private GameObject itemBox;

    private GameObject shopUI;

    private RectTransform itemBoxParent;

    private Image selectItemSprite;

    private TextMeshProUGUI selectItemName;
    private TextMeshProUGUI selectItemDescription;
    private Button btnBuy;

    private List<GameObject> spawnedButtons = new List<GameObject>();

	private void Start()
	{
        itemBox = ShopManager.instance.itemBox;
        shopUI = ShopManager.instance.shopUI;
        itemBoxParent = ShopManager.instance.itemBoxParent;
        selectItemSprite = ShopManager.instance.selectItemSprite;
        selectItemName = ShopManager.instance.selectItemName;
        selectItemDescription = ShopManager.instance.selectItemDescription;
        btnBuy = ShopManager.instance.btnBuy;
    }

	public void OpenShop(Rigidbody2D _rb, PlayerController playerScript)
    {
        ShopManager.instance.isOpen = !ShopManager.instance.isOpen;
		if (playerScript.isMapOpen == true) return;
        if (Inventory.Controller.instance.isOpen == true) return;

        if (ShopManager.instance.isOpen == false)
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

            GameObject outline = g.transform.GetChild(0).GetChild(2).gameObject;
            g.GetComponent<UISelectItem>().Setup(item, selectItemSprite, selectItemName, selectItemDescription, btnBuy, outline);
            
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

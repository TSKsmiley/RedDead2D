using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    [Header("UI")]
    public GameObject itemBox;

    public GameObject shopUI;

    public RectTransform itemBoxParent;

    [Header("Selected Item UI")]
    public Image selectItemSprite;

    public TextMeshProUGUI selectItemName;
    public TextMeshProUGUI selectItemDescription;
    public Button btnBuy;

    public bool isOpen = false;

    public void Awake()
	{
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

}

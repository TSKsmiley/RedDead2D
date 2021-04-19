using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    public Money money;

    public TextMeshProUGUI moneyText;

    private void Awake()
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

    private void Start()
    {
        RefreshMoneyUI();
    }

    public void RefreshMoneyUI()
    {
        moneyText.text = $"${money.currMoney.ToString()}";
    }

    public void AddMoney(int moneyToAdd)
    {
        money.currMoney += moneyToAdd;
        RefreshMoneyUI();
    }
    
    public void RemoveMoney(int moneyToRemove)
    {
        money.currMoney -= moneyToRemove;
        RefreshMoneyUI();
    }

    public bool canAfford(int itemPrice)
    {
        if (itemPrice > money.currMoney)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

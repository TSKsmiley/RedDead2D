using System;
using System.Collections.Generic;
using UnityEngine;
using static Inventory.Interfaces;

namespace Inventory
{
    public class Controller : MonoBehaviour
    {
        public static int InventorySize = 35;
        public GameObject UIObjectsParrent;
        public List<ItemObject> UIObjects = new List<ItemObject>();
        public ItemStack[] Inventory = new ItemStack[InventorySize];

        public void Start()
        {
            foreach (var item in UIObjectsParrent.GetComponentsInChildren<ItemObject>())
            {
                UIObjects.Add(item);
            }
            refreshUI();
        }

        public bool hasItem(IItem item)
        {
            foreach (ItemStack currItem in Inventory)
            {
                if (currItem.Item.name == item.name) return true;
            }

            return false;
        }

        public List<int> findItem(IItem item)
        {
            List<int> results = new List<int>();
            for (int i = 0; i < Inventory.Length; i++)
            { 
                if (Inventory[i].Item.name == item.name) results.Add(i);
            }

            return results;
        }

        public void refreshUI()
        {
            for (int i = 0; i < InventorySize; i++)
            {
                if(Inventory[i] == null)
                UIObjects[i].Item = Inventory[i].Item;
                UIObjects[i].UpdateUI();
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using static Inventory.Interfaces;

namespace Inventory
{
    public class Controller : MonoBehaviour
    {
        public static int InventorySize = 36;
        public GameObject UIObjectsParrent;
        public List<ItemObject> UIObjects = new List<ItemObject>();
        public List<ScriptableObject> StartingItems = new List<ScriptableObject>();
        public ItemStack[] Inventory = new ItemStack[InventorySize];

        public GameObject InvGui;

        public void Start()
        {
            foreach (var item in UIObjectsParrent.GetComponentsInChildren<ItemObject>())
            {
                UIObjects.Add(item);
            }

            for (int i = 0; i < StartingItems.Count; i++)
            {
                Inventory[i] = new ItemStack(StartingItems[i] as IItem);
            }
            
            RefreshUI();
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

        public void CloseInv()
        {
            InvGui.SetActive(false);
        }

        public void OpenInv()
        {
            InvGui.SetActive(true);
        }
        
        public void RefreshUI()
        {
            for (int i = 0; i < InventorySize; i++)
            {
                if(Inventory[i].Item == null) continue;
                UIObjects[i].Item = Inventory[i].Item;
                UIObjects[i].UpdateUI();
            }
        }
        
    }
}

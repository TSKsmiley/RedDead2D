using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using static Inventory.Interfaces;

namespace Inventory
{
    public class Controller : MonoBehaviour
    {
        public List<ScriptableObject> startingItems = new List<ScriptableObject>();
        
        [Header("UI Parrents")] //UI Parrents
        public GameObject invGui;
        public GameObject hotbarGui;
        public bool isOpen;
        
        
        
        [Header("Main inv")] //Main inv
        public static int InventorySize = 36;
        public ItemStack[] Inventory = new ItemStack[InventorySize];
        [SerializeField][Range(0,8)]private int selectedIndex = 0;
        
        
        
        [Header("Main inv UI")] //Main inv
        public GameObject uiObjectsParrent;
        public List<ItemObject> uiObjects = new List<ItemObject>();
        

        
        [Header("Hotbar UI")] // Hotbar vars
        public GameObject hotbarObjectsParrent;
        public RectTransform selectedRect;
        public List<GameObject> hotbarObjects = new List<GameObject>();
       
        
        public void Start()
        {
            InitializeUI();
            
            for (int i = 0; i < startingItems.Count; i++)
            {
                Inventory[i] = new ItemStack(startingItems[i] as IItem);
            }
            
            RefreshUI();
            Select(0);
        }

        private void InitializeUI()
        {
            foreach (var item in uiObjectsParrent.GetComponentsInChildren<ItemObject>())
            {
                uiObjects.Add(item);
            }

            foreach (var item in hotbarObjectsParrent.GetComponentsInChildren<ItemObject>())
            {
                hotbarObjects.Add(item.gameObject);
            }
        }

        public bool HasItem(IItem item)
        {
            foreach (ItemStack currItem in Inventory)
            {
                if (currItem.Item.name == item.name) return true;
            }

            return false;
        }

        /// <summary>
        /// Finds all instances of a given item in the inventory
        /// </summary>
        /// <param name="item"></param>
        /// <returns>a list of indexes where the item exists</returns>
        public List<int> FindItem(IItem item)
        {
            List<int> results = new List<int>();
            for (int i = 0; i < Inventory.Length; i++)
            { 
                if (Inventory[i].Item.name == item.name) results.Add(i);
            }

            return results;
        }

        public void ToggleInv()
        {
            isOpen = !isOpen;
            invGui.SetActive(isOpen);
            hotbarGui.SetActive(!isOpen);
        }
        
        public void CloseInv()
        {
            invGui.SetActive(false);
            hotbarGui.SetActive(true);
            isOpen = false;
        }

        public void OpenInv()
        {
            invGui.SetActive(true);
            hotbarGui.SetActive(false);
            isOpen = true;
        }

        public void Select(int i)
        {
            selectedIndex = i;
            selectedRect.position = hotbarObjects[i].GetComponent<RectTransform>().position;
        }
        
        public void SelectNext()
        {
            selectedIndex = selectedIndex == 8 ? 0 : selectedIndex+1;
            
            selectedRect.position = hotbarObjects[selectedIndex].GetComponent<RectTransform>().position;
        }

        public void SelectPrevious()
        {
            selectedIndex = selectedIndex == 0 ? 8 : selectedIndex-1;
            
            selectedRect.position = hotbarObjects[selectedIndex].GetComponent<RectTransform>().position;
        }
        
        public ItemStack GetSelectedItem()
        {
            return Inventory[selectedIndex];
        }
        public int GetSelectedIndex()
        {
            return selectedIndex;
        }
        
        public void RefreshUI()
        {
            
            for (int i = 0; i < InventorySize; i++)
            {
                if (Inventory[i] != null)
                {
                    uiObjects[i].Item = Inventory[i].Item;
                    uiObjects[i].UpdateUI();
                }
            }
            
            for (int i = 0; i < 9; i++)
            {
                if(Inventory[i] == null) continue;
                hotbarObjects[i].GetComponent<ItemObject>().Item = Inventory[i].Item;
                hotbarObjects[i].GetComponent<ItemObject>().UpdateUI();
            }
            
        }
        
    }
}

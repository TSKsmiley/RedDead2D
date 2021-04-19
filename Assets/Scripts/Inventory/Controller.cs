using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Inventory
{
    public class Controller : MonoBehaviour
    {
        public List<Item> startingItems = new List<Item>();
        
        [Header("UI Parents")] //UI Parents
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


        
        [Header("Weapon UI")]
        public GameObject weaponUI;
        public TextMeshProUGUI currAmmo;
        public TextMeshProUGUI chamberSize;
        
        
        
        public static Controller instance;

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

        public void Start()
        {
            InitializeUI();
            
            for (int i = 0; i < startingItems.Count; i++)
            {
                AddItem(startingItems[i]);
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

        public bool HasItem(Item item)
        {
            foreach (ItemStack currItem in Inventory)
            {
                if (currItem.Item.name == item.name) return true;
            }

            return false;
        }

        public void AddItem(Item item)
        { 
            if (item.maxStack > 1)
            {
                var existingItems = FindItem(item);
                if (existingItems.Count == 0)
                {
                    Inventory[FindFirstEmpty()] = new ItemStack(item);
                }
                else
                {
                    Inventory[existingItems[0]].Quantity++;
                }
            }
            else
            {
                Inventory[FindFirstEmpty()] = new ItemStack(item);
            }
        }
        
        public void AddItem(Item item, int amount)
        { 
            if (item.maxStack > 1)
            {
                // STACKABLE ITEMS
                var existingItems = FindItem(item);
                if (existingItems.Count == 0)
                {
                    Inventory[FindFirstEmpty()] = new ItemStack(item);
                }
                else
                {
                    Inventory[existingItems[0]].Quantity += amount;
                }
            }
            else
            {
                // NON STACKABLE ITEMS
                for (int i = 0; i < amount; i++)
                {
                    Inventory[FindFirstEmpty()] = new ItemStack(item);
                }
            }
        }

        /// <summary>
        /// Finds all instances of a given item in the inventory
        /// </summary>
        /// <param name="item"></param>
        /// <returns>a list of indexes where the item exists</returns>
        public List<int> FindItem(Item item)
        {
            List<int> results = new List<int>();
            for (int i = 0; i < Inventory.Length; i++)
            { 
                if (Inventory[i]?.Item.name == item.name) results.Add(i);
            }

            return results;
        }

        /// <summary>
        /// Finds the next empty spot in the inventory
        /// </summary>
        /// <returns>index array for empty spots</returns>
        public List<int> FindEmpty()
        {
            List<int> results = new List<int>();
            for (int i = 0; i < Inventory.Length; i++)
            { 
                if (Inventory[i] == null) results.Add(i);
            }

            return results;
        }
        
        public int FindFirstEmpty()
        {
            for (int i = 0; i < Inventory.Length; i++)
            { 
                if (Inventory[i] == null) return i;
            }
            return -1;
        }
        
        
        /// <summary>
        /// Finds all instances of a given item name in the inventory
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns>a list of indexes where the item exists</returns>
        public List<int> FindItemByName(string itemName)
        {
            List<int> results = new List<int>();
            for (int i = 0; i < Inventory.Length; i++)
            {
                if (Inventory[i]?.Item.name == itemName) results.Add(i);
            }

            return results;
        }
        
        /// <summary>
        /// Removes a given amount of items from the inventory
        /// </summary>
        /// <returns>An int representing the amount of removed items</returns>
        public int RemoveItems(int _amount, string _itemName)
        {
            int removeCount = 0; // we keep track of how many times we have removed an item

            // We search for some ammo and order it highest to lowest value
            List<int> results = FindItemByName(_itemName).OrderByDescending(v => v).ToList();

            if (results.Count == 0) return 0; // If we didn't find any item, simply return 0

            
            if (Inventory[results[0]].Item.maxStack > 1)
            {
                ////// Stackable items
                
            }
            else
            {
                ////// non-stackable items
                if (results.Count < _amount) _amount = results.Count; // If what we found is less than what we need, we set what we found to what we need (prevents errors)

                // Loop through inventory to take items
                for (int i = 0; i < _amount; i++)
                {
                    Inventory[results[i]] = null; // Find the item at the index and remove it (by setting it to null)
                    removeCount++; // We just removed something
                }
            }
            
            
           

            RefreshUI(); // Refresh the UI in order to update the inventory items visually
            return removeCount; // Return the amount we removed
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
            
            CheckItemType();
        }

        public void SelectNext()
        {
            selectedIndex = selectedIndex == 8 ? 0 : selectedIndex+1;
            selectedRect.position = hotbarObjects[selectedIndex].GetComponent<RectTransform>().position;
            
            CheckItemType();
        }

        public void SelectPrevious()
        {
            selectedIndex = selectedIndex == 0 ? 8 : selectedIndex-1;
            selectedRect.position = hotbarObjects[selectedIndex].GetComponent<RectTransform>().position;
            
            CheckItemType();
        }
        
        public ItemStack GetSelectedItem()
        {
            return Inventory[selectedIndex];
        }
        public int GetSelectedIndex()
        {
            return selectedIndex;
        }

        private void CheckItemType()
        {
            ItemStack item = GetSelectedItem();
            if (item != null)
            {
                switch (item.Item.GetType().ToString())
                {
                    case "Inventory.RangedWeaponItem":
                        EnableWeaponUI(item.Item as RangedWeaponItem);
                        break;
                    
                    default:
                        DisableWeaponUI();
                        break;
                }
            }
        }
        
        public void EnableWeaponUI(RangedWeaponItem _weapon)
        {
            UpdateAmmo(_weapon.currAmmo.ToString(), _weapon.chamberSize.ToString());
            
            weaponUI.SetActive(true);
        }

        public void DisableWeaponUI()
        {
            weaponUI.SetActive(false);
        }

        public void UpdateAmmo(string _currAmmo, string _chamberSize)
        {
            currAmmo.text = _currAmmo;
            chamberSize.text = _chamberSize;
        }
        
        public void RefreshUI()
        {
            
            for (int i = 0; i < InventorySize; i++)
            {
                if (Inventory[i] != null)
                {
                    uiObjects[i].Item = Inventory[i].Item;
                    uiObjects[i].UpdateUI(Inventory[i].Quantity);
                }
                else
                {
                    uiObjects[i].spriteRenderer.enabled = false;
                }
            }
            
            for (int i = 0; i < 9; i++)
            {
                // if a item is removed from the inventory make sure to actually remove it from the ui by disabling the rendere
                if (Inventory[i] == null)
                {
                    hotbarObjects[i].GetComponent<ItemObject>().spriteRenderer.enabled = false;
                }
                else
                {
                    hotbarObjects[i].GetComponent<ItemObject>().Item = Inventory[i].Item;
                    hotbarObjects[i].GetComponent<ItemObject>().UpdateUI(Inventory[i].Quantity);
                }
                
            }
            
        }
        
    }
}

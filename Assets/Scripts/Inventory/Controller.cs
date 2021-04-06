using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Inventory
{
    public class Controller : MonoBehaviour
    {
        public Item[] Inventory = new Item[20];

        public bool hasItem(Item item)
        {
            foreach (Item currItem in Inventory)
            {
                if (currItem.name == item.name) return true;
            }

            return false;
        }

        public List<int> findItem(Item item)
        {
            List<int> results = new List<int>();
            for (int i = 0; i < Inventory.Length; i++)
            { 
                if (Inventory[i].name == item.name) results.Add(i);
            }

            return results;
        }
        
    }
}

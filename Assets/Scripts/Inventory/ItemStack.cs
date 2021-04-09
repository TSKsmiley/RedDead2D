using UnityEngine;
using static Inventory.Interfaces;

namespace Inventory
{
    public class ItemStack
    {
        public ScriptableObject Item;
        public int Quantity;

        public ItemStack(ScriptableObject item)
        {
            Item = item;
            Quantity = 1;
        }
    }
}
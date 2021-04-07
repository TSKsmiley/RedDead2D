using UnityEngine;
using static Inventory.Interfaces;

namespace Inventory
{
    public class ItemStack
    {
        public IItem Item;
        public int Quantity;

        public ItemStack(IItem item)
        {
            Item = item;
            Quantity = 1;
        }
    }
}
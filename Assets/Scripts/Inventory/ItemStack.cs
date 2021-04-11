using UnityEngine;

namespace Inventory
{
    public class ItemStack
    {
        public Item Item;
        public int Quantity;

        public ItemStack(Item item)
        {
            Item = item;
            Quantity = 1;
        }
    }
}
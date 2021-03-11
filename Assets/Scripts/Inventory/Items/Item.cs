using UnityEngine;

namespace Inventory.Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Items/item")]
    public class Item : ScriptableObject
    {
        public new string name;
        public string description;
    
        public Sprite sprite;
    }
}

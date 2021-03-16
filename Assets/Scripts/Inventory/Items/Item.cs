using UnityEngine;
using UnityEngine.Serialization;

namespace Inventory.Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Items/item")]
    public class Item : ScriptableObject, IItem
    {
        [field: SerializeField,InspectorName("Name")]
        public string itemName { get; set; }
        
        [field: SerializeField]
        public string description { get; set; }
        
        [field: SerializeField]
        public typeEnum type { get; set; }
        
        [field: SerializeField]
        public Sprite sprite { get; set; }

        public Item()
        {
            type = typeEnum.BasicItem;
        }
    }
}

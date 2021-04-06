using UnityEngine;
using UnityEngine.Serialization;

namespace Inventory
{
    [CreateAssetMenu(fileName = "Item")]
    public class Item : ScriptableObject
    {
        public string itemName;

        public string description;

        public itemTypeEnum type;

        public Sprite sprite;

        public Item()
        {
            type = itemTypeEnum.BASIC;
        }
        
        public enum itemTypeEnum
        {
            BASIC,
            MELEE,
            RANGED
        }
    }
}

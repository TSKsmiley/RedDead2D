using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
    public class Item : ScriptableObject, Interfaces.IItem
    {
        [field: SerializeField]
        public new string name {get;set;}

        [field: SerializeField]
        public string description {get;set;}

        [field: SerializeField]
        public int goldValue {get;set;}

        [field: SerializeField]
        public Sprite sprite {get;set;}

        [field: SerializeField]
        public bool stackable {get;set;}

        public void Equip() {

        }
    }
}

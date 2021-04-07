using UnityEngine;

namespace Inventory 
{
    [CreateAssetMenu(fileName = "ConsumerableItem", menuName = "Items/ConsumerableItem")]
    public class ConsumableItem : ScriptableObject, Interfaces.IItem, Interfaces.IConsumerable
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

        public int healthRegen {get;set;}

        public void Equip() 
        {

        }

        public void ApplyHealthRegen() 
        {

        }
    }

}

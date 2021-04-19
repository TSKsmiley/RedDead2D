using UnityEngine;
using UnityEngine.UIElements;

namespace Inventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
    public class Item : ScriptableObject
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
        public int maxStack { get; set; } = 1;

        public void Equip() {

        }
        
        public virtual void Use(InputMaster _playerInput, GameObject _caller) { }

        public virtual void ControllerUse(InputMaster _playerInput, GameObject _caller) { }
    }
}

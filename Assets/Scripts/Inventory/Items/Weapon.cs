using UnityEngine;

namespace Inventory.Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Items/weapon")]
    public class ItemWeapon : ScriptableObject
    {
        public new string name;
        public string description;
    
        public Sprite sprite;

        public int damage;
    }
}

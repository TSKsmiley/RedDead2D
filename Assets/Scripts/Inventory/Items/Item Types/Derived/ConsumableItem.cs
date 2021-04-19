using UnityEngine;

namespace Inventory 
{
    [CreateAssetMenu(fileName = "ConsumerableItem", menuName = "Items/ConsumerableItem")]
    public class ConsumableItem : Item
    {
        [field: SerializeField]
        public int healthRegen {get;set;}
        
        public override void Use(InputMaster _playerInput, GameObject _caller)
        {
            Debug.Log("consumable");   
        }
        
        public override void ControllerUse(InputMaster _playerInput, GameObject _caller)
        {
            Debug.Log("consumable controller");
        }

        public void ApplyHealthRegen() 
        {

        }
    }

}

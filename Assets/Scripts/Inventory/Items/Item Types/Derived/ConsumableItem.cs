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
            ApplyHealthRegen(_caller.GetComponent<PlayerController>());
            
        }
        
        public override void ControllerUse(InputMaster _playerInput, GameObject _caller)
        {
            Debug.Log("consumable controller");
            
            ApplyHealthRegen(_caller.GetComponent<PlayerController>());
        }

        public void ApplyHealthRegen(PlayerController player)
        {
            int healthToAdd = healthRegen - player.currHealth;
            player.currHealth += healthToAdd;
            
            player.healthBar.SetHealth(player.currHealth);
        }
    }

}

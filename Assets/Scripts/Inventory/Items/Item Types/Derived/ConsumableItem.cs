using UnityEngine;

namespace Inventory 
{
    [CreateAssetMenu(fileName = "ConsumerableItem", menuName = "Items/ConsumerableItem")]
    public class ConsumableItem : Item
    {
        public int healthRegen;
        
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
            if (player.currHealth == 100) return;
            int healthToAdd = healthRegen + player.currHealth;
            if (healthToAdd > 100)
            {
                player.currHealth += player.maxHealth - player.currHealth;
            }
            else
            {
                player.currHealth += healthRegen;
            }

            player.healthBar.SetHealth(player.currHealth);
            Inventory.Controller.instance.RemoveItems(1, this.name);
        }
    }

}

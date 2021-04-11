using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class QuestItem : Item
    {
        public override void Use(InputMaster _playerInput, GameObject _caller)
        {
            Debug.Log("Used questitem with keyboard");
        }
        
        public override void ControllerUse(InputMaster _playerInput, GameObject _caller)
        {
            Debug.Log("Used questitem with controller");
        }
        
        private void TurnIn()
        {
            
        }
    }

}

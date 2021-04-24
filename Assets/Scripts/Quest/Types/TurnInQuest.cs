using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory;

namespace QuestSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "TurnInQuest", menuName = "Quest/TurnInQuest", order = 0)]
    public class TurnInQuest : Quest
    {
        // - - - PROPERTIES - - - 
        public Item TurnInItem;
        public Dialogue[] followUpDialogue;

        public override void CheckCompleteConditions(Collider2D _trigger, GameObject _caller)
        {
            if (TurnInItem != null)
            {
                Inventory.Controller.instance.RemoveItems(1, TurnInItem.name);
                if (followUpDialogue.Length != 0) DialogueManager.instance.StartDialogue(followUpDialogue[0]);
                QuestManager.instance.CompleteActive();
            }
        }
    }
}

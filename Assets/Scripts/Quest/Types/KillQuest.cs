using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "KillQuestObject", menuName = "Quest/KillQuest", order = 0)]
    public class KillQuest : Quest
    {
        // - - - PROPERTIES - - - 
        public GameObject target;
        public Dialogue[] followUpDialogue;

        public override void CheckCompleteConditions(Collider2D _trigger, GameObject _caller)
        {
            if (_caller.name == target.name)
            {
                if (followUpDialogue.Length != 0) DialogueManager.instance.StartDialogue(followUpDialogue[0]);
                QuestManager.instance.CompleteActive();
            }
        }
    }
}

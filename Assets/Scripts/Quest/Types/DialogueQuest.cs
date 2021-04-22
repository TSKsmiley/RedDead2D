using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace QuestSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "DialogueQuestObject", menuName = "Quest/DialogueQuest", order = 0)]
    public class DialogueQuest : Quest
    {
        // - - - PROPERTIES - - - 
        public GameObject NPC;

        public GameObject QuestIcon;
        public Dialogue[] dialogue;

        //TODO: RewardItem (item class not yet impemented)

        public override void CheckCompleteConditions(Collider2D _trigger, GameObject _caller)
        {
            if (_trigger == null) return;
            if (_trigger.name == NPC.name) NPC.GetComponent<DialogueTrigger>().TriggerDialogue(null);
        }
    }
}
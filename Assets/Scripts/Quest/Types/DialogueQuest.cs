using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace QuestSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "DialogueQuestObject", menuName = "Quest/DialogueQuest", order = 0)]
    public class DialogueQuest : ScriptableObject
    {
        // - - - PROPERTIES - - - 
        
        public string Name;
        public string Description;
        public string Objective;

        public int RewardMoney;

        public GameObject NPC;

        public GameObject QuestIcon;
        public Dialogue[] dialogue;

        //TODO: RewardItem (item class not yet impemented)
    }
}
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace QuestSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "QuestObject", menuName = "Scriptable Objects/Quest", order = 0)]
    public class Quest : ScriptableObject
    {
        // - - - PROPERTIES - - - 
        
        public string Name;
        public string Description;
        public string Objective;

        public int RewardMoney;

        public GameObject NPC;
        public Dialogue[] dialogue;

        //TODO: RewardItem (item class not yet impemented)
    }
}
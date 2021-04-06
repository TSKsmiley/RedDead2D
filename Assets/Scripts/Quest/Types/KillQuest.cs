using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "KillQuestObject", menuName = "Quest/KillQuest", order = 0)]
    public class KillQuest : ScriptableObject
    {
        // - - - PROPERTIES - - - 
        
        public string Name;
        public string Description;
        public string Objective;
        public GameObject target;
        public Dialogue[] dialogue;
    }
}

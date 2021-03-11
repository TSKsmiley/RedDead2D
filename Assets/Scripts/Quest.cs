using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace QuestSystem
{
    public class Quest
    {
        // - - - PROPERTIES - - - 
        
        public readonly string Name;
        public readonly string Description;
        public string Objective { get; set; }
        
        
        public int RewardMoney { get; set; }
        //TODO: RewardItem (item class not yet impemented)

        
        public static List<Quest> AllQuests = new List<Quest>();
        public static int ActiveQuest = 0;
        
        public static TextMeshProUGUI txtName;
        public static TextMeshProUGUI txtObjective;
        public static TextMeshProUGUI txtDescription;

        
        // - - - CONSTRUCTORS - - - 
        public Quest(string name,string description,string objective)
        {
            //Basics
            Name = name;
            Description = description;
            Objective = objective;
            
            //add quest to master list
            AllQuests.Add(this);
        }
        public Quest(string name,string description,string objective,int rewardMoney)
        {
            //Basics
            Name = name;
            Description = description;
            Objective = objective;
            
            //add quest to master list
            RewardMoney = rewardMoney;
            AllQuests.Add(this);
        }
        
        // - - - STATIC METHODS - - - 

        public static void SetUi(TextMeshProUGUI name,TextMeshProUGUI objective, TextMeshProUGUI description)
        {
            txtName = name;
            txtObjective = objective;
            txtDescription = description;
        }

        public static void CompleteActive()
        {
            ActiveQuest++;
            AllQuests[ActiveQuest].Start();
        }

        public static void CompleteID(int questID)
        {
            ActiveQuest = questID + 1;
            AllQuests[ActiveQuest].Start();
        }

        public static Quest GetActive()
        {
            return AllQuests[ActiveQuest];
        }
        
        // - - - METHODS - - - 

        public void Start()
        {
            txtName.text = Name;
            txtObjective.text = $"Objective: {Objective}";
            txtDescription.text = Description;
        }
        
    }
}
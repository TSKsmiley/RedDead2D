using System;
using System.Collections;
using System.Collections.Generic;
using QuestSystem;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public TextMeshProUGUI QuestName;
    public TextMeshProUGUI QuestObjective;
    public TextMeshProUGUI QuestDescription;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Quest.SetUi(QuestName, QuestObjective, QuestDescription);
        new Quest("Space", "do you even space bro ", "press space to complete this test quest (0/1)");
        Quest.AllQuests[0].Start();
    }

    // Update is called once per frame
    void Update()
    {
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using QuestSystem;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Quest.AllQuests[0].Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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
        Quest.StartNew("Space", "do you even space bro", "press space to complete this test quest");
        Quest.AllQuests[0].Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Quest.CompleteActive();
    }
}

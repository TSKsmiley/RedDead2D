using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        if (DialogueManager.instance.isDialogueStarted == false)
        {
            DialogueQuest activeQuest = (DialogueQuest)QuestManager.instance.GetActive();
            DialogueManager.instance.StartDialogue(activeQuest.dialogue[0]);
        }
    }
}
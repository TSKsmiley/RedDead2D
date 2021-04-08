using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using QuestSystem;

public class DialogueTrigger : MonoBehaviour
{
    public string speakerName;
    public Dialogue[] dialogue;

    public void TriggerDialogue(Dialogue diag)
    {
        if (diag == null)
        {
            DialogueQuest activeQuest = (DialogueQuest)QuestManager.instance.GetActive();
            DialogueManager.instance.isQuestDialogue = true;
            DialogueManager.instance.StartDialogue(activeQuest.dialogue[0]);
        }
        else
        {
            DialogueManager.instance.isQuestDialogue = false;
            DialogueManager.instance.StartDialogue(diag);
        }
    }
}
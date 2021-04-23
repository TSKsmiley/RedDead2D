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
            
            // play sound clip for the greeting
            DialogueQuest DQ = (DialogueQuest) QuestManager.instance.GetActive();

            AudioManager.instance.Play(DQ.sfxClip);
            DialogueManager.instance.StartDialogue(activeQuest.dialogue[0]);
        }
        else
        {
            DialogueManager.instance.isQuestDialogue = false;
            
            // play sound clip for the greeting
            DialogueQuest DQ = (DialogueQuest) QuestManager.instance.GetActive();
            AudioManager.instance.Play(DQ.sfxClip);
            
            DialogueManager.instance.StartDialogue(diag);
        }
    }
}
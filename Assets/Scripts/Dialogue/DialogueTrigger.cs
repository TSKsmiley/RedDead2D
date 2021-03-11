using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        if (DialogueManager.instance.isInDialogue == false)
        {
            DialogueManager.instance.StartDialogue(QuestManager.instance.GetActive().dialogue[0]);
            QuestManager.instance.CompleteActive();
        }
    }
}